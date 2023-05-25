using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex_Fixação_MVC.Model
{
    public class Eventos
    {
        public string NomeEvento { get; set; }
        public DateTime Data { get; set; }
        public float PrecoIngresso { get; set; }

        private const string PATH = "Database/Eventos.csv";

        public Eventos()
        {

            // Criação da database
            string pasta = PATH.Split("/")[0];
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(PATH))
            {
                File.Create(PATH);
            }
        }

        public List<Eventos> Ler()
        {
            List<Eventos> eventos = new List<Eventos>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] separador = item.Split(";");
                
                Eventos e = new Eventos();

                e.NomeEvento = separador[0];
                e.Data = DateTime.Parse(separador[1]);
                e.PrecoIngresso = float.Parse(separador[2]);

                eventos.Add(e);

            }


            return eventos;
        }

        public string ListaOrganizada(Eventos e)
        {
            return $"{e.NomeEvento};{e.Data};{e.PrecoIngresso}";
        }

        public void inserir(Eventos e)
        {
            string[] linhas = {ListaOrganizada(e)};

            File.AppendAllLines(PATH,linhas);
        }
    }
}