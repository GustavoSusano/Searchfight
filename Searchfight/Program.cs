using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Configuration;

namespace Searchfight
{
    class Program
    {
        static void Main(string[] args)
        {
            int arg_size = args.Length;
            List<Lenguaje> listadoLenguajes = new List<Lenguaje>();
            int i;
            for (i = 0; i < arg_size; i++)
            {
                
                Websearch search = new Websearch();
                
                //Google
                String Url = System.Configuration.ConfigurationManager.AppSettings["Direccion1"];
                String data_google = search.Buscarnavegador(Url, args[i].ToString(), ConfigurationManager.AppSettings["CadenaIni1"].Replace("%22>", "\">"), ConfigurationManager.AppSettings["CadenaFin1"]);
                listadoLenguajes.Add(new Lenguaje() { Buscador = ConfigurationManager.AppSettings["Buscador1"], Busqueda = Convert.ToInt64(data_google), Nombre = args[i].ToString() });
                
               //MSN Search
               Url = ConfigurationManager.AppSettings["Direccion2"];
               //string sample = ConfigurationManager.AppSettings["CadenaIni2"].Replace("%22>", "\">");
                String data_bing = search.Buscarnavegador(Url, args[i].ToString(), ConfigurationManager.AppSettings["CadenaIni2"].Replace("%22>", "\">"), ConfigurationManager.AppSettings["CadenaFin2"]);
                listadoLenguajes.Add(new Lenguaje() { Buscador = ConfigurationManager.AppSettings["Buscador2"], Busqueda = Convert.ToInt64(data_bing), Nombre = args[i].ToString() });

                Console.WriteLine(args[i].ToString() + ": "+ ConfigurationManager.AppSettings["Buscador1"] + ": " + data_google + " "+ ConfigurationManager.AppSettings["Buscador2"] + ": " +
                                  data_bing);


            }

            String googlewinner ="", msnwinner = "";
            long googlelong= 0, msnlong = 0;
            List<Lenguaje> listadoganadores = new List<Lenguaje>();
            foreach (Lenguaje len in listadoLenguajes)
            {
                if (len.Buscador.Equals(ConfigurationManager.AppSettings["Buscador1"]))
                {
                    if (googlelong < len.Busqueda)
                    {
                        googlewinner = len.Nombre;
                        googlelong = len.Busqueda;
                    }
                }

                if (len.Buscador.Equals(ConfigurationManager.AppSettings["Buscador2"]))
                {
                    if (msnlong < len.Busqueda)
                    {
                        msnwinner = len.Nombre;
                        msnlong = len.Busqueda;
                    }
                }

                Boolean nuevo = true;
                foreach (Lenguaje len_gan in listadoganadores)
                {
                    if (len_gan.Nombre.Equals(len.Nombre))
                    {
                        nuevo = false;
                        len_gan.LenguajeMayor = len_gan.LenguajeMayor + len.Busqueda;
                    }
                }

                if (nuevo)
                    {
                        listadoganadores.Add(new Lenguaje()
                        {
                            Nombre = len.Nombre,
                            LenguajeMayor = len.Busqueda
                        });
                    }
            }

            Console.WriteLine(ConfigurationManager.AppSettings["Buscador1"]+" winner: " + googlewinner);
            Console.WriteLine(ConfigurationManager.AppSettings["Buscador2"]+" winner: " + msnwinner);

            long winner = 0;
            String win = "";
            foreach (Lenguaje len_gan in listadoganadores)
            {
                if (winner < len_gan.LenguajeMayor)
                {
                    win = len_gan.Nombre;
                    winner = len_gan.LenguajeMayor;
                }
            }

            Console.WriteLine("Total winner: " + win);
        }

    }
}
