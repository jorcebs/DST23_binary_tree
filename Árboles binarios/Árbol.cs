using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Árboles_binarios
{
    class Árbol
    {
        private Nodo raíz;

        public void Agregar(Nodo nuevo)
        {
            if (raíz == null)
                raíz = nuevo;
            else
                Agregar(nuevo, raíz);
        }

        private void Agregar(Nodo nuevo, Nodo nodo)
        {
            if (nuevo.dato < nodo.dato)
            {
                if (nodo.izquierdo == null)
                    nodo.izquierdo = nuevo;
                else
                    Agregar(nuevo, nodo.izquierdo);
            }
            else
            {
                if (nodo.derecho == null)
                    nodo.derecho = nuevo;
                else
                    Agregar(nuevo, nodo.derecho);
            }
        }

        public Nodo Buscar(int dato)
        {
            if (raíz != null)
            {
                if (dato == raíz.dato)
                    return raíz;
                else
                    return Buscar(dato, raíz);
            }
            else
                return null;
        }

        private Nodo Buscar(int dato, Nodo nodo)
        {
            if (dato < nodo.dato)
            {
                if (nodo.izquierdo != null)
                {
                    if (dato == nodo.izquierdo.dato)
                        return nodo.izquierdo;
                    else
                        return Buscar(dato, nodo.izquierdo);
                }
                else
                    return null;
            }
            else
            {
                if (nodo.derecho != null)
                {
                    if (dato == nodo.derecho.dato)
                        return nodo.derecho;
                    else
                        return Buscar(dato, nodo.derecho);
                }
                else
                    return null;
            }
        }

        private Nodo BuscarPadre(int dato)
        {
            return BuscarPadre(dato, raíz);
        }

        private Nodo BuscarPadre(int dato, Nodo nodo)
        {
            if (dato < nodo.dato)
            {
                if (nodo.izquierdo != null)
                {
                    if (dato == nodo.izquierdo.dato)
                        return nodo;
                    else
                        return BuscarPadre(dato, nodo.izquierdo);
                }
                else
                    return null;
            }
            else
            {
                if (nodo.derecho != null)
                {
                    if (dato == nodo.derecho.dato)
                        return nodo;
                    else
                        return BuscarPadre(dato, nodo.derecho);
                }
                else
                    return null;
            }
        }

        private bool EsHoja(int dato)
        {
            Nodo nodo = Buscar(dato);
            if (nodo.izquierdo == null && nodo.derecho == null)
                return true;
            else
                return false;
        }

        private bool TieneUnHijo(int dato)
        {
            Nodo nodo = Buscar(dato);
            if ((nodo.izquierdo != null && nodo.derecho == null) || (nodo.izquierdo == null && nodo.derecho != null))
                return true;
            else
                return false;
        }

        List<Nodo> list = new List<Nodo>();
        private Nodo MayorSiguiente(Nodo nodo)
        {
            list.Clear();
            InOrder(nodo.derecho);
            return list.ElementAt(0);
        }

        private void EliminarHoja(int dato)
        {
            Nodo padre = BuscarPadre(dato);
            if (padre.izquierdo != null && padre.izquierdo.dato == dato)
                padre.izquierdo = null;
            else
                padre.derecho = null;
        }

        private void EliminarPadreDeUnHijo(int dato)
        {
            Nodo padre = BuscarPadre(dato);
            // Si el nodo a eliminar está a la izquierda
            if (padre.izquierdo != null && padre.izquierdo.dato == dato)
            {
                // Si el hijo del nodo a eliminar está a la izquierda
                if (padre.izquierdo.izquierdo != null)
                    padre.izquierdo = padre.izquierdo.izquierdo;
                // Si el hijo del nodo a eliminar está a la izquierda
                else
                    padre.izquierdo = padre.izquierdo.derecho;
            }
            // Si el nodo a eliminar está a la derecha
            else
            {
                // Si el hijo del nodo a eliminar está a la izquierda
                if (padre.derecho.izquierdo != null)
                    padre.derecho = padre.derecho.izquierdo;
                // Si el hijo del nodo a eliminar está a la izquierda
                else
                    padre.derecho = padre.derecho.derecho;
            }
        }

        public bool Eliminar(int dato)
        {
            if (Buscar(dato) == null)
                return false;
            else
            {
                eliminar(dato, raíz);
                return true;
            }
        }

        private void eliminar(int dato, Nodo nodo)
        {
            if (EsHoja(dato))
            {
                EliminarHoja(dato);
            }
            else if (TieneUnHijo(dato))
            {
                EliminarPadreDeUnHijo(dato);
            }
            else
            {
                //Nodo mayorSiguiente = MayorSiguiente(Buscar(dato).derecho);
                //if (EsHoja(mayorSiguiente.dato))
                //{
                //    Nodo padre = BuscarPadre(dato);
                //    EliminarHoja(mayorSiguiente.dato);
                //}
            }
        }
        
        public String PreOrder()
        {
            if (raíz == null)
                return "";
            else
                return PreOrder(raíz);
        }

        private String PreOrder(Nodo nodo)
        {
            String resultado = "";
            resultado += nodo.ToString() + ",";
            if (nodo.izquierdo != null)
                resultado += PreOrder(nodo.izquierdo);
            if (nodo.derecho != null)
                resultado += PreOrder(nodo.derecho);
            return resultado;
        }

        public String InOrder()
        {
            if (raíz == null)
                return "";
            else
                return InOrder(raíz);
        }

        private String InOrder(Nodo nodo)
        {
            String resultado = "";
            if (nodo.izquierdo != null)
                resultado += InOrder(nodo.izquierdo);
            resultado += nodo.ToString() + ",";
            list.Add(nodo);
            if (nodo.derecho != null)
                resultado += InOrder(nodo.derecho);
            return resultado;
        }

        public String PostOrder()
        {
            if (raíz == null)
                return "";
            else
                return PostOrder(raíz);
        }

        private String PostOrder(Nodo nodo)
        {
            String resultado = "";
            if (nodo.izquierdo != null)
                resultado += PostOrder(nodo.izquierdo);
            if (nodo.derecho != null)
                resultado += PostOrder(nodo.derecho);
            resultado += nodo.ToString() + ",";
            return resultado;
        }
    }
}