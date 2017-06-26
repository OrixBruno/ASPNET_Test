using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orix.AlocacaoDeHoras.Web.ViewModels
{
    public class DetalheViewModel
    {
        public int IdPeriodo { get; set; }
        public string NomeProfissional { get; set; }
        public string DescricaoCentroCusto { get; set; }
        public string InicioPeriodo { get; set; }
        public string FimPeriodo { get; set; }
        public string TotalMinutos { get; set; }
        public string MinutosReportados { get; set; }
        public int? TotalMinutosTrabalhados { get; set; }
        public string HorasAReportar { get; set; }
        public string CaminhoImagemProfissional { get; set; }
        public bool? Editavel { get; set; }
        public string IdentificadorProjetoPadrao { get; set; }
        public int? IndiceAtual { get; set; }
        public bool? PermiteAlocacaoAutomatica { get; set; }
        public string DescricaoMesAno { get; set; }
        public List<CentroCustoViewModel> CentroCustos { get; set; }
        public int? StatusPeriodoApontamento { get; set; }
        public int? CodigoStatusApontamentoHoraPeriodoReporte { get; set; }
    }
}
