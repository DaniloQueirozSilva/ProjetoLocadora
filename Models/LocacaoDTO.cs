using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLocadora.Controllers
{
    public class LocacaoDTO
    {
        public int idFilme { get; set; }
        public int idLocador { get; set; }
        public string dateDevolucao { get; set; }
        
    }
}