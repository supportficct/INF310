using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otra
{
    public class Nodo
    {
        #region Atributos
        public int elemento;
        public Nodo padre;
        public Nodo enlaceDer;
        public Nodo enlaceIzq;
        public int altura;
        public int nivel;
        #endregion

        #region Property
        public int Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }

        public Nodo Padre
        {
            get { return padre; }
            set { padre = value; }
        }

        public Nodo EnlaceDer
        {
            get { return enlaceDer; }
            set { enlaceDer = value; }
        }

        public Nodo EnlaceIzq
        {
            get { return enlaceIzq; }
            set { enlaceIzq = value; }
        }
        int Altura
        {
            get { return altura; }
            set { altura = value; }
        }

        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }
        #endregion

        #region Metodos
        public Boolean EsPadre()
        {
            if (padre == null) return true;
            return false;
        }
        public Boolean Eshoja()
        {
            if ((enlaceDer == null) && (enlaceIzq == null)) return true;
            return false;
        }

        
        public Nodo insert(int elem, ref Nodo p)
        {
            if (p == null)
            {
                p = new Nodo(elem, p);
                p.nivel = 1;
            }
            else
            {
                if (elem > p.elemento)
                {
                    Nodo hd = p.enlaceDer;
                    hd = insert(elem, ref hd);
                    if (p.nivel == hd.nivel)
                    {
                        p.nivel++;
                    }
                    p.enlaceDer = hd;
                    p.enlaceDer.padre = p;
                }
                if (elem < p.elemento)
                {
                    Nodo hi = p.enlaceIzq;
                    hi = insert(elem, ref hi);
                    if (p.nivel == hi.nivel)
                    {
                        p.nivel++;
                    }
                    p.enlaceIzq = hi;
                    p.enlaceIzq.padre = p;
                }

            }
            return p;
        }
        public Nodo Actualizar(ref Nodo p, int n)
        {

            if ((p.enlaceDer != null) && (p.enlaceIzq != null))
            {
                p.enlaceIzq.nivel = n - 1;
                p.enlaceDer.nivel = n - 1;
                Actualizar(ref p.enlaceDer, p.enlaceDer.nivel);
                Actualizar(ref p.enlaceIzq, p.enlaceIzq.nivel);

            }
            if ((p.enlaceDer == null) && (p.enlaceIzq != null))
            {
                p.enlaceIzq.nivel = n - 1;
                Actualizar(ref p.enlaceIzq, p.enlaceIzq.nivel);
            }
            if ((p.enlaceIzq == null) && (p.enlaceDer != null))
            {
                p.enlaceDer.nivel = n - 1;
                Actualizar(ref p.enlaceDer, p.enlaceDer.nivel);
            }
            return p;
        }
         
    
        public void ObtenerElmN(ref String[] v, Nodo p, int n, ref int aux)
        {
            if ((p.enlaceDer == null) && (p.enlaceIzq == null))
            {

                if (p.nivel != n)
                {
                    int e = exp(2, p.nivel - n);
                    v = rec(e, ref v, ref aux);
                }
            }
            if ((p.enlaceDer != null) && (p.enlaceIzq != null))
            {
                if ((p.enlaceIzq.nivel == n) && (p.enlaceDer.nivel == n))
                {
                    v[aux] = p.enlaceIzq.elemento + "";
                    aux++;
                    v[aux] = p.enlaceDer.elemento + "";
                    aux++;
                    /*if (p.padre != null)
                    {
                        ObtenerElmN(ref v, p.padre, n, ref aux);
                    }*/
                }
                else
                {
                    // aux++;
                    ObtenerElmN(ref v, p.enlaceIzq, n, ref aux);
                    //aux++;
                    ObtenerElmN(ref v, p.enlaceDer, n, ref aux);
                }
            }
            if ((p.enlaceDer == null) && (p.enlaceIzq != null))
            {
                if (p.enlaceIzq.nivel == n)
                {
                    v[aux] = p.enlaceIzq.elemento + "";
                    aux++;
                    v[aux] = "-1";
                    aux++;
                }
                else
                {
                    if (p.enlaceDer != null)
                    {
                        int e = exp(2, p.nivel - n);
                        e = e / 2;
                        v = rec(e, ref v, ref aux);
                    }

                }
                ObtenerElmN(ref v, p.enlaceIzq, n, ref aux);
            }
            if ((p.enlaceIzq == null) && (p.enlaceDer != null))
            {
                if ((p.enlaceDer.nivel == n))
                {
                    v[aux] = "-1";
                    aux++;
                    v[aux] = p.enlaceDer.elemento + "";
                    aux++;

                }
                else
                {

                    int e = exp(2, p.nivel - n);
                    e = e / 2;
                    v = rec(e, ref v, ref aux);
                }

                /*if((p.enlaceIzq == null))
                {
                        
                }*/
                //aux++;
                ObtenerElmN(ref v, p.enlaceDer, n, ref aux);
            }
            //return v;
        }
        public int exp(int b, int exp)
        {
            int r = b;
            if (exp == 0)
            {
                return 1;
            }

            for (int x = 1; x < exp; x++)
            {
                r = r * b;
            }
            return r;
        }
        public String[] rec(int n, ref String[] v, ref int r)
        {

            for (int x = 1; x <= n; x++)
            {
                v[r] = "-1";
                r++;
            }
            return v;
        }


        public void balancear()
        {

        }

        #endregion

        #region Constructor
        public Nodo()
        {
            padre = enlaceDer = enlaceIzq = null;
            altura = 0;
            nivel = 0;
            elemento = 0;
        }
        public Nodo(int elem, Nodo p)
        {
            elemento = elem;
            padre = p;
        }

        #endregion
    }
}
