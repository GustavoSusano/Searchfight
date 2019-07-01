using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Searchfight
{

    public class Lenguaje : IEquatable<Lenguaje>
    {
        public string Nombre { get; set; }

        public long Busqueda { get; set; }

        public long LenguajeMayor { get; set; }

        public string Buscador { get; set; }

        public bool Equals(Lenguaje other)
        {
            if (other == null) return false;
            return (this.Busqueda.Equals(other.Busqueda));
        }
        

    }
}
