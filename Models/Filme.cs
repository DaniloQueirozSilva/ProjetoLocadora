using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace ProjetoLocadora.Models
{
    public class Filme
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public int Ano { get; set; }


        public List<Filme> ListarFilmes()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\BaseFilme.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaFilme = JsonConvert.DeserializeObject<List<Filme>>(json);

            return listaFilme;
        }

        public bool RescreverArquivo(List<Filme> listaFilme)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\BaseFilme.json");
            var json = JsonConvert.SerializeObject(listaFilme, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;

        }

        public Filme Create(Filme filme)
        {
            var listaFilme = this.ListarFilmes();

            var maxId = listaFilme.Max(p => p.id);
            filme.id = maxId + 1;
            listaFilme.Add(filme);


            RescreverArquivo(listaFilme);
            return filme;

        }

        public Filme Update(int id, Filme Filme)
        {
            var listaFilme = this.ListarFilmes();

            var itemIndex = listaFilme.FindIndex(p => p.id == Filme.id);
            if (itemIndex >= 0)
            {
                Filme.id = id;
                listaFilme[itemIndex] = Filme;
            }
            else
            {
                return null;
            }

            RescreverArquivo(listaFilme);
            return Filme;
        }

        public bool Delete(int id)
        {
            var listaFilme = this.ListarFilmes();

            var itemIndex = listaFilme.FindIndex(p => p.id == id);
            if (itemIndex >= 0)
            {
                listaFilme.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            RescreverArquivo(listaFilme);
            return true;
        }
    }
}