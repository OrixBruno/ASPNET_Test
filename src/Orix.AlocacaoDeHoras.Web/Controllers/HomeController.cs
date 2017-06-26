using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orix.AlocacaoDeHoras.Web.ViewModels;
using Orix.AlocacaoDeHoras.Web.Utils;
using Newtonsoft.Json;
using System.Globalization;

namespace Orix.AlocacaoDeHoras.Web.Controllers
{
    public class HomeController : Controller
    {
        //ROTAS PADRÕES
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }

        //Rotas auxiliares
        public IActionResult Logar(ContaViewModel contaTela)
        {
            var cliente = new HttpClientRequests("http://portal.brq.com");
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                ViewBag.Retorno = "Erro na alocação de horas! Dia da semana não permitido para alocação de horas!"; ViewBag.Class = "danger";

            using (cliente.client)
            {
                var modelReturn = JsonConvert.DeserializeObject<ContaViewModel>(cliente.SendRequestPost("/Login/Login", JsonConvert.SerializeObject(contaTela)).Result);

                var resultHoraPonto = cliente.SendRequestGet("WidgetBaterPonto/ObterDataHoraServidor?_=1495555241490").Result;

                var periodos = new List<PeriodoViewModel>();
                var detalhe = new DetalheViewModel();

                if (modelReturn != null)
                    periodos = JsonConvert.DeserializeObject<List<PeriodoViewModel>>(cliente.SendRequestGet("/ApontamentoHoras/ListarReportesDoPeriodo?idPeriodo=0").Result);
                if (periodos != null)
                    detalhe = JsonConvert.DeserializeObject<DetalheViewModel>(cliente.SendRequestGet($"/ApontamentoHoras/CarregarDetalhesMes?matriculaProfissional={periodos[0].MatriculaProfissional}&ano={periodos[0].Ano}&mes={periodos[0].Mes}&indicePeriodo={periodos[0].IdReporte}").Result);

                if (detalhe != null)
                {
                    var envio = new
                    {
                        detalhes = new DetalheViewModel()
                        {
                            IdPeriodo = detalhe.IdPeriodo,
                            CentroCustos = new List<CentroCustoViewModel>()
                    {
                        new CentroCustoViewModel()
                        {
                            IdCentroCusto = detalhe.CentroCustos[0].IdCentroCusto,
                            Projetos = new List<ProjetoViewModel>()
                            {
                                new ProjetoViewModel()
                                {
                                    IdProjeto = detalhe.CentroCustos[0].Projetos[0].IdProjeto,
                                    HorasReportadas = $"{(int.Parse(detalhe.CentroCustos[0].Projetos[0].HorasReportadas.Substring(0, 2)) + int.Parse(detalhe.HorasAReportar.Substring(0, 2))).ToString("d2")}:"+
                                                      $"{(int.Parse(detalhe.CentroCustos[0].Projetos[0].HorasReportadas.Substring(3, 2)) + int.Parse(detalhe.HorasAReportar.Substring(3, 2))).ToString("d2")}",
                                    StatusApontamento = detalhe.CentroCustos[0].Projetos[0].StatusApontamento
                                }
                            }
                        }
                    }
                        }
                    };

                    var envioAlocar = JsonConvert.SerializeObject(envio, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    //if (cliente.SendRequestPost("/ApontamentoHoras/SalvarReporte", envioAlocar).Result == "true")
                    //{ ViewBag.Retorno = "Horas alocadas com sucesso!"; ViewBag.Class = "success"; }
                    //else
                    //{ ViewBag.Retorno = "Erro na alocação de horas!"; ViewBag.Class = "danger"; }
                }
                return View(modelReturn);
            }
        }
    }
}
