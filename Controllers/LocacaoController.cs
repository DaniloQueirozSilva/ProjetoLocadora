using ProjetoLocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ProjetoLocadora.Controllers
{
    public class LocacaoController : ApiController
    {
        // GET: api/Locacao
        public IEnumerable<Locacao> Get()
        {
            Locacao locacao = new Locacao();
            return locacao.ListarLocacao();                 
            
        }

       
        // POST: api/Locacao
        public List<Locacao> Post([FromBody]LocacaoDTO locacao)
        {

            Locacao _locacao = new Locacao();

            Filme filme = new Filme();
            var procurarFilme = filme.ListarFilmes().Where(x => x.id == locacao.idFilme).FirstOrDefault();

            if (procurarFilme != null)
            {
                DateTime dt1 = Convert.ToDateTime(locacao.dateDevolucao);


                _locacao.Create(locacao.idFilme, locacao.idLocador, locacao.dateDevolucao);

                return _locacao.ListarLocacao();


            }
            else
            {
                throw new ArgumentException($"ID de filme fornecido não existe");
                
            }

        }

        // PUT: api/Locacao/5
        public Object Put(int id, [FromBody]Locacao locacao)
        {
            Locacao _locacao = new Locacao();

            var info = _locacao.ListarLocacao().Where(x => x.id == id).FirstOrDefault();

            DateTime data = DateTime.Today;
            if (data > info.DataDevolucao)
            {
                HttpResponseMessage x = Request.CreateResponse(HttpStatusCode.OK, "Devolução em atraso");
                _locacao.Update(id, locacao);
                return x;
            }
            else
            {
                _locacao.Update(id, locacao);
            }
            

            return Ok();
          
        }

        // DELETE: api/Locacao/5
        public void Delete(int id)
        {
        }
    }
}
