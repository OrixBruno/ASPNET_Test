using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orix.AlocacaoDeHoras.Web.ViewModels
{
    public class ContaViewModel
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool SalvarUsuario { get; set; }
        public bool TrocarSenha { get; set; }
        public string RedirectUrl { get; set; }
        public bool CredencialValida { get; set; }
    }
}
