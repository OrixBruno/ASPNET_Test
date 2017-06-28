using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreTeste.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using AspNetCoreTeste.IServices;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreTeste.Controllers
{
    public class ListaController : Controller
    {
        CalendarioConfig _calendar = new CalendarioConfig();
        PregacaoSemanaViewModel _semanaCampo;
        IPregacaoService _service;
        DateTime _dataPrimeiraTercaMes, _primeiroDiaMes, _ultimoDiaMes;

        public ListaController(IPregacaoService service)
        {
            _service = service;
            _semanaCampo = new PregacaoSemanaViewModel();
            _dataPrimeiraTercaMes = DateTime.Now;
            _primeiroDiaMes = DateTime.Parse("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
            _ultimoDiaMes = DateTime.Parse(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
        }

        // GET: /<controller>/
        public IActionResult Campo(int id)
        {
            _semanaCampo = _service.GetLista().Result[id];
            return View(_calendar.getCalender(DateTime.Now.Month, DateTime.Now.Year, _semanaCampo));
        }
        public IActionResult CampoPorData()
        {
            var result = _service.GetListaPorData().Result;
            ViewBag.ListaDatas = result.Select(x => x.Date).Distinct().Select(x => new SelectListItem()
            {
                Text = x.ToString("d"),
                Value = x.ToString()
            });

            return View();
        }
        [HttpPost]
        public IActionResult CampoPorData(DateTime date)
        {
            _semanaCampo = _service.GetPorData(date).Result;
            return View("Campo", _calendar.getCalender(DateTime.Now.Month, DateTime.Now.Year, _semanaCampo));
        }
        public IActionResult Gerador()
        {
            VerificaPrimeiraTercaSemana(_calendar.GetDateInfo(_primeiroDiaMes));
            GerarListaDirigentes();
            GerarListaSaidas();
            GerarTodasTerçasMes();

            return View(_semanaCampo);
        }
        [HttpPost]
        public IActionResult Gerador(PregacaoSemanaViewModel pregacaoSemana)
        {
            _semanaCampo = pregacaoSemana;
            AdicionarDatasSemana(_semanaCampo.CampoTerca1.Dia);
            var pregacao = _service.Create(pregacaoSemana);
            var lista = _service.GetLista();
            return View("Campo", _calendar.getCalender(_semanaCampo.CampoDomingo.Dia.Month, _semanaCampo.CampoDomingo.Dia.Year, _semanaCampo));
        }

        //METODOS
        #region Metodos Geradores
        private void GerarListaDirigentes()
        {
            ViewBag.SelectListDirigente = new List<SelectListItem>() {
                new SelectListItem() { Text = "Marcos", Value = "Marcos" },
                new SelectListItem() { Text = "Rafael", Value = "Rafael" },
                new SelectListItem() { Text = "Geraíldo", Value = "Geraíldo" },
                new SelectListItem() { Text = "Bruno", Value = "Bruno" },
                new SelectListItem() { Text = "Henrique", Value = "Henrique" },
                new SelectListItem() { Text = "Evandro", Value = "Evandro" },
                new SelectListItem() { Text = "William", Value = "William" },
                new SelectListItem() { Text = "Bonifácio", Value = "Bonifácio" },
                new SelectListItem() { Text = "Antônio", Value = "Antônio" },
                new SelectListItem() { Text = "Jonathan", Value = "Jonathan" },
                new SelectListItem() { Text = "José Carlos", Value = "José Carlos" },
                new SelectListItem() { Text = "Josimar Maciel", Value = "Josimar" },
                new SelectListItem() { Text = "Roberto", Value = "Roberto" },
                new SelectListItem() { Text = "Wesley Girotto", Value = "Wesley" },
                new SelectListItem() { Text = "Carlos Augusto", Value = "Carlos" },
                new SelectListItem() { Text = "Heverton", Value = "Heverton" },
                new SelectListItem() { Text = "Emerson", Value = "Emerson" },
                new SelectListItem() { Text = "Maycon", Value = "Maycon" },
                new SelectListItem() { Text = "Sullen", Value = "Sullen" },
                new SelectListItem() { Text = "Vlazia", Value = "Vlazia" },
                new SelectListItem() { Text = "Kelma", Value = "Kelma" },
                new SelectListItem() { Text = "Ricardo", Value = "Ricardo" }
            };
        }
        private void GerarListaSaidas()
        {
            ViewBag.SelectListSaidas = new List<SelectListItem>() {
                new SelectListItem() { Text = "Casa do Roberto", Value = "Casa do Roberto" },
                new SelectListItem() { Text = "Casa do Carlos", Value = "Casa do Carlos" },
                new SelectListItem() { Text = "Casa do Maciel", Value = "Casa do Maciel" },
                new SelectListItem() { Text = "Salão do Reino", Value = "Salão do Reino" },
                new SelectListItem() { Text = "Salão LS Itaim", Value = "Salão LS Itaim" },
                new SelectListItem() { Text = "Salão LS Ferraz", Value = "Salão LS Ferraz" },
                new SelectListItem() { Text = "Salão Fazenda Itaim", Value = "Salão Fazenda Itaim" },
                new SelectListItem() { Text = "Salão Parque Real", Value = "Salão Parque Real" },
                new SelectListItem() { Text = "Salão Jardim Senice", Value = "Salão Jardim Senice" },
                new SelectListItem() { Text = "Salão LS Guaianases", Value = "Salão LS Guaianases" },
                new SelectListItem() { Text = "Salão Camargo Velho", Value = "Salão Camargo Velho" }
            };
        }
        private void GerarTodasTerçasMes()
        {
            ViewBag.SelectListSemanas = new List<SelectListItem>() {
                new SelectListItem() { Text =  _dataPrimeiraTercaMes.ToString("dd/MM/yyyy"), Value = _dataPrimeiraTercaMes.ToString("dd/MM/yyyy") },
                new SelectListItem() { Text = _dataPrimeiraTercaMes.AddDays(7).ToString("dd/MM/yyyy"), Value = _dataPrimeiraTercaMes.AddDays(7).ToString("dd/MM/yyyy") },
                new SelectListItem() { Text = _dataPrimeiraTercaMes.AddDays(14).ToString("dd/MM/yyyy"), Value = _dataPrimeiraTercaMes.AddDays(14).ToString("dd/MM/yyyy") },
                new SelectListItem() { Text =  _dataPrimeiraTercaMes.AddDays(21).ToString("dd/MM/yyyy"), Value = _dataPrimeiraTercaMes.AddDays(21).ToString("dd/MM/yyyy") },
                new SelectListItem() { Text = _dataPrimeiraTercaMes.AddDays(28).ToString("dd/MM/yyyy"), Value = _dataPrimeiraTercaMes.AddDays(28).ToString("dd/MM/yyyy") },
            };
        }
        #endregion

        private void VerificaPrimeiraTercaSemana(int primeiroDiaSemana)
        {
            switch (primeiroDiaSemana)
            {
                case 0:
                    _semanaCampo.CampoTerca1.Dia = _primeiroDiaMes.AddDays(2);
                    _dataPrimeiraTercaMes = _primeiroDiaMes.AddDays(2);
                    break;
                case 1:
                    _semanaCampo.CampoTerca1.Dia = _primeiroDiaMes.AddDays(1);
                    _dataPrimeiraTercaMes = _primeiroDiaMes.AddDays(1);
                    break;
                case 2:
                    _semanaCampo.CampoTerca1.Dia = _primeiroDiaMes;
                    _dataPrimeiraTercaMes = _primeiroDiaMes;
                    break;
                case 3:
                    _semanaCampo.CampoTerca1.Dia = _primeiroDiaMes.AddDays(-1);
                    _dataPrimeiraTercaMes = _primeiroDiaMes.AddDays(-1);
                    break;
                case 4:
                    _semanaCampo.CampoTerca1.Dia = _primeiroDiaMes.AddDays(-2);
                    _dataPrimeiraTercaMes = _primeiroDiaMes.AddDays(-2);
                    break;
                case 5:
                    _semanaCampo.CampoTerca1.Dia = _primeiroDiaMes.AddDays(-3);
                    _dataPrimeiraTercaMes = _primeiroDiaMes.AddDays(-3);
                    break;
                case 6:
                    _semanaCampo.CampoTerca1.Dia = _primeiroDiaMes.AddDays(-4);
                    _dataPrimeiraTercaMes = _primeiroDiaMes.AddDays(-4);
                    break;
            }            
        }
        private void AdicionarDatasSemana(DateTime primeiraTerca)
        {
            _semanaCampo.CampoSegunda1.Dia = primeiraTerca.AddDays(-1);
            _semanaCampo.CampoSegunda2.Dia = primeiraTerca.AddDays(-1);
            _semanaCampo.CampoQuarta1.Dia = primeiraTerca.AddDays(1);
            _semanaCampo.CampoQuarta2.Dia = primeiraTerca.AddDays(1);
            _semanaCampo.CampoQuinta1.Dia = primeiraTerca.AddDays(2);
            _semanaCampo.CampoQuinta2.Dia = primeiraTerca.AddDays(2);
            _semanaCampo.CampoSexta1.Dia = primeiraTerca.AddDays(3);
            _semanaCampo.CampoSexta2.Dia = primeiraTerca.AddDays(3);
            _semanaCampo.CampoSabado1.Dia = primeiraTerca.AddDays(4);
            _semanaCampo.CampoSabado2.Dia = primeiraTerca.AddDays(4);
            _semanaCampo.CampoSabado3.Dia = primeiraTerca.AddDays(4);
            _semanaCampo.CampoDomingo.Dia = primeiraTerca.AddDays(5);
        }

    }
}
