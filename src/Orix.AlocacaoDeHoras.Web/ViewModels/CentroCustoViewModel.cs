using System.Collections.Generic;

namespace Orix.AlocacaoDeHoras.Web.ViewModels
{
    public class CentroCustoViewModel
    {
        public int IdCentroCusto { get; set; }
        public string Descricao { get; set; }
        public List<ProjetoViewModel> Projetos { get; set; }
    }
}