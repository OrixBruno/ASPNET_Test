using System;
using System.Collections.Generic;

namespace Orix.AlocacaoDeHoras.Web.ViewModels
{
    public class ProjetoViewModel
    {
        public int IdProjeto { get; set; }
        public string Descricao { get; set; }
        public string TotalMinutos { get; set; }
        public string IdentificadorProjeto { get; set; }
        public string Oferta { get; set; }
        public string HorasReportadas { get; set; }
        public int? IdApontamento { get; set; }
        public int? StatusApontamento { get; set; }
        public bool? Editavel { get; set; }
    }
}