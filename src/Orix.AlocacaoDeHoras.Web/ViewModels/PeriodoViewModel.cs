using System;
using System.Collections.Generic;

namespace Orix.AlocacaoDeHoras.Web.ViewModels
{
    public class PeriodoViewModel
    {
        public int IdReporte { get; set; }
        public string InicioPeriodo { get; set; }
        public string FimPeriodo { get; set; }
        public string TotalHorasPeriodoTrabalho { get; set; }
        public int? MatriculaProfissional { get; set; }
        public int? Ano { get; set; }
        public int? Mes { get; set; }
        public List<ProjetoViewModel> Projetos { get; set; }
        public int? TotalLinhas { get; set; }
        public int? IndexLinhas { get; set; }
    }
}
