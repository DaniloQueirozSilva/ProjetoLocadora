using ProjetoLocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoLocadora.Controllers
{
    public class FilmesController : ApiController
    {
        // GET: api/Filmes
        public IEnumerable<Filme> Get()
        {
            Filme filme = new Filme();
            return filme.ListarFilmes();
        }

        // GET: api/Filmes/5
        public Filme Get(int id)
        {
            Filme filme = new Filme();

            return filme.ListarFilmes().Where(x => x.id == id).FirstOrDefault();
        }

        // POST: api/Filmes
        public List<Filme> Post([FromBody] Filme filme)
        {
            Filme _filme = new Filme();
            _filme.Create(filme);
            return _filme.ListarFilmes();
        }

        // PUT: api/Filmes/5
        public Filme Put(int id, [FromBody] Filme filme)
        {
            Filme _filme = new Filme();
            return _filme.Update(id, filme);
        }

        // DELETE: api/Filmes/5
        public void Delete(int id)
        {
            Filme _filme = new Filme();
            _filme.Delete(id);
        }
    }
}