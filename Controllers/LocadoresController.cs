using ProjetoLocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoLocadora.Controllers
{
    public class LocadoresController : ApiController
    {
        // GET: api/Locadores
        public IEnumerable<Locador> Get()
        {
            Locador locador = new Locador();
            return locador.ListarLocador();
        }

        // GET: api/Locadores/5
        public Locador Get(int id)
        {
            Locador locador = new Locador();

            return locador.ListarLocador().Where(x => x.id == id).FirstOrDefault();
        }

        // POST: api/Locadores
        public List<Locador> Post([FromBody]Locador locador)
        {
            Locador _locador = new Locador();
            _locador.Create(locador);

            return _locador.ListarLocador();
        }

        // PUT: api/Locadores/5
        public Locador Put(int id, [FromBody]Locador locador
            )
        {
            Locador _locador = new Locador();
            return _locador.Update(id, locador);
        }

        // DELETE: api/Locadores/5
        public void Delete(int id)
        {
            Locador _locador = new Locador();
            _locador.Delete(id);
        }
    }
}
