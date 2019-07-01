using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.IO;


namespace Searchfight
{
    class Websearch
    {
        public string Buscarnavegador(String Url, String nombre, String CadenaResult, String CadenaResultFin)
        {
            String cadena = WebSearch(Url, nombre);
            string valor = getCantidad(cadena, CadenaResult, CadenaResultFin);
            string reval1 = valor.Replace(",", "");
            string refin = reval1.Replace(".", "");
            return refin;
        }

        
        
        static String WebSearch(string uriBase, string searchQuery)
        {
            // Construct the search request URI.
            string  uriQuery = uriBase + "?q=" + Uri.EscapeDataString(searchQuery);

            var request = (HttpWebRequest) WebRequest.Create(uriQuery);

            request.Credentials = CredentialCache.DefaultCredentials;
          
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            string webresult = "";
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                webresult = sr.ReadToEnd();
            }
            
            return webresult;
        }


        public static string getCantidad(string strFuente, string strInicio, string strFin)
        {
            int Ini, Term;
            if (strFuente.Contains(strInicio) && strFuente.Contains(strFin))
            {
                Ini = strFuente.IndexOf(strInicio, 0) + strInicio.Length;
                Term = strFuente.IndexOf(strFin, Ini);
                return strFuente.Substring(Ini, Term - Ini);
            }
            else
            {
                return "";
            }
        }

    }
}
