using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Árboles_binarios
{
    class Nodo
    {
        public int dato { private set; get; }
        public Nodo izquierdo;
        public Nodo derecho;

        public Nodo(int dato)
        {
            this.dato = dato;
        }

        public override string ToString()
        {
            return dato.ToString();
        }
    }
}