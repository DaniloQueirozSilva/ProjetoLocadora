using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace ProjetoLocadora.Models
{
    public class Locacao
    {
        public int id { get; set; }
        public DateTime DataDevolucao { get; set; }
        public Filme filme { get; set; }
        public Locador locador { get; set; }
        public string alugado { get; set; }



        public List<Locacao> ListarLocacao()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\BaseLocacao.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaLocacao = JsonConvert.DeserializeObject<List<Locacao>>(json);

            return listaLocacao;
        }

        public bool RescreverArquivo(List<Locacao> listaLocacao)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\BaseLocacao.json");
            var json = JsonConvert.SerializeObject(listaLocacao, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;

        }

        public Locacao Create(int idFilme, int idLocador, string dataDevolucao)
        {

            Locacao locacao = new Locacao();
            var listaLocacao = this.ListarLocacao();

            Filme filme = new Filme();
            var listaFilme = filme.ListarFilmes();
            var procurarFilme = listaFilme.Find(p => p.id == idFilme);
            locacao.filme = procurarFilme;

            Locador locador = new Locador();
            var listaLocador = locador.ListarLocador();
            var procurarLocador = listaLocador.Find(p => p.id == idLocador);
            locacao.locador = procurarLocador;

            locacao.DataDevolucao = Convert.ToDateTime(dataDevolucao);
            locacao.alugado = "alugado";

            var maxId = listaLocacao.Max(p => p.id);
            locacao.id = maxId + 1;
            
            listaLocacao.Add(locacao);



            RescreverArquivo(listaLocacao);
            return locacao;

        }

        public Locacao Update(int id, Locacao locacao)
        {
            var listarLocacao = this.ListarLocacao();
            var itemIndex = listarLocacao.FindIndex(p => p.id == locacao.id);

            if(itemIndex >= 0)
            {
                locacao.id = id;
                locacao.alugado = "Devolvido";
                listarLocacao[itemIndex] = locacao;
            }
            else
            {
                return null;
            }

            RescreverArquivo(listarLocacao);
            return locacao;
        }
    }
}