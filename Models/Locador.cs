using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace ProjetoLocadora.Models
{

    public class Locador
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int funcional { get; set; }



        public List<Locador> ListarLocador()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\Base.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaLocador = JsonConvert.DeserializeObject<List<Locador>>(json);

            return listaLocador;
        }

        public bool RescreverArquivo(List<Locador> listaLocador)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data\Base.json");
            var json = JsonConvert.SerializeObject(listaLocador, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);

            return true;

        }
        public Locador Create(Locador locador)
        {
            var listaLocador = this.ListarLocador();

            var maxId = listaLocador.Max(p => p.id);
            locador.id = maxId + 1;
            listaLocador.Add(locador);


            RescreverArquivo(listaLocador);
            return locador;

        }

        public Locador Update(int id, Locador Locador)
        {
            var listaLocador = this.ListarLocador();

            var itemIndex = listaLocador.FindIndex(p => p.id == Locador.id);
            if (itemIndex >= 0)
            {
                Locador.id = id;
                listaLocador[itemIndex] = Locador;
            }
            else
            {
                return null;
            }

            RescreverArquivo(listaLocador);
            return Locador;
        }

        public bool Delete(int id)
        {
            var listaLocador = this.ListarLocador();

            var itemIndex = listaLocador.FindIndex(p => p.id == id);
            if (itemIndex >= 0)
            {
                listaLocador.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            RescreverArquivo(listaLocador);
            return true;
        }


    }

}