using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otra
{
    public class Arbol
    {
        #region Atributos_Property
        public Nodo raiz;
        public int cantidad;
        public Nodo PadreS;
        public Nodo PadreN;
        
   
        public bool Vacio()
        {
            return raiz == null;
        }
        #endregion
        #region Metodos
        public void insert(int elem)
        {
            Nodo aux = new Nodo();
            if (cantidad == 0)
            {
                aux = null;
                raiz = raiz.insert(elem, ref aux);
                raiz.nivel = 1;
            }
            else
            {
                raiz = raiz.insert(elem, ref raiz);
                raiz.Actualizar(ref raiz, raiz.nivel);

            }

            cantidad++;
        }
        public String[] ObtenerElmN(int n)
        {
            String[] v = new String[100];
            if ((raiz.padre == null) && (raiz.nivel == n))
            {
                v[0] = raiz.elemento + "";
                return v;
            }
            int s = 0;
            raiz.ObtenerElmN(ref v, raiz, n, ref s);
            return v;
        }

        #endregion
        public bool esHoja()
        {
            return esHoja(raiz);
        }

        private bool esHoja(Nodo nodoAct)
        {
            if (nodoAct == null)
                return false;
            return nodoAct.enlaceIzq == null && nodoAct.enlaceDer == null;
        }
        public Nodo NodoN(int x)
        {
            PadreN = null;
            Nodo p = raiz;
            while (p != null)
            {
                if (p.Elemento == x)
                {
                    return p;
                }
                PadreN = p;
                if (x < p.elemento)
                {
                    p = p.enlaceIzq;
                }
                else
                {
                    p = p.enlaceDer;
                }
            }
            PadreN = null;
            return p;
        }

        public Nodo SucesorI(Nodo nodoAct)
        {
            PadreS = nodoAct;
            Nodo S = nodoAct.enlaceDer;
            while (S.enlaceIzq != null)
            {
                PadreS = S;
                S = S.enlaceIzq;
            }
            return S;
        }

        public int cantHijos(Nodo nodoAct)
        {
            if (nodoAct == null)
            {
                return 0;
            }
            int cant = 0;
            if (nodoAct.enlaceIzq != null)
            {
                cant++;
            }
            if (nodoAct.enlaceDer != null)
            {
                cant++;
            }
            return cant;
        }
        #region Eliminar     ///un dato
        //ELIMINAR UN NODO

        public void caso0(Nodo nodoAct, Nodo nodoAnt)
        {
            if (nodoAct != null)
            {
                if (nodoAct.enlaceIzq == nodoAnt)
                {
                    nodoAct.EnlaceIzq = null;
                }
                else
                {
                    nodoAct.EnlaceDer = null;
                }
            }
            else
            {
                raiz = null;
            }
        }

        public void caso1(Nodo nodoAct, Nodo nodoAnt)
        {
            if (nodoAct == null)
            {
                if (nodoAnt.enlaceIzq != null)
                {
                    raiz = nodoAnt.enlaceIzq;
                    nodoAct.EnlaceDer = null;
                }
                else
                {
                    if (nodoAnt.enlaceIzq != null)
                    {
                        raiz = nodoAnt.enlaceDer;
                        nodoAct.EnlaceDer = null;
                    }
                }
            }
            else
            {
                if (nodoAnt.enlaceIzq != null)
                {
                    if (nodoAct.enlaceIzq == nodoAnt)
                    {
                        nodoAct.EnlaceIzq = nodoAnt.enlaceIzq;
                        nodoAnt.EnlaceIzq = null;
                    }
                    else
                    {
                        if (nodoAct.enlaceDer == nodoAnt)
                        {
                            nodoAct.EnlaceDer = nodoAnt.enlaceIzq;
                            nodoAnt.EnlaceIzq = null;
                        }
                    }
                }
                else
                {
                    if (nodoAnt.enlaceDer != null)
                    {
                        if (nodoAct.enlaceIzq == nodoAnt)
                        {
                            nodoAct.EnlaceIzq = nodoAnt.enlaceDer;
                            nodoAnt.EnlaceDer = null;
                        }
                        else
                        {
                            if (nodoAct.enlaceDer == nodoAnt)
                            {
                                nodoAct.EnlaceDer = nodoAnt.enlaceDer;
                                nodoAnt.EnlaceDer = null;
                            }
                        }
                    }
                }
            }
        }

        public void caso2(Nodo nodoAct, Nodo nodoAnt)
        {
            if (nodoAct == null)
            {
                raiz.elemento = nodoAnt.enlaceDer.elemento;
                raiz.EnlaceDer = null;
            }
            else
            {
                Nodo S = this.SucesorI(nodoAnt);
                int hijos = this.cantHijos(S);
                switch (hijos)
                {
                    case 0: nodoAnt.elemento = S.elemento;
                        caso0(PadreS, S); break;

                    case 1: nodoAnt.elemento = S.elemento;
                        caso1(PadreS, S); break;
                }
            }
        }

        public void Eliminar(int dato)
        {
            Nodo nodoAct = NodoN(dato);
            if (nodoAct != null)
            {
                int hijos = this.cantHijos(nodoAct);
                switch (hijos)
                {
                    case 0: caso0(PadreN, nodoAct); break;
                    case 1: caso1(PadreN, nodoAct); break;
                    case 2: caso2(PadreN, nodoAct); break;
                }
            }
            else
            {
                // System.out.print("El dato no existe");
            }
        }
#endregion  

       

        public bool BuscarEleI(int dato)
        {
            if (Vacio())
            {
                return false;
            }
            else
            {
                Nodo nodoAct = raiz;
                Nodo nodoAnt = null;
                while (nodoAct != null)
                {
                    nodoAnt = nodoAct;
                    if (nodoAct.Elemento == dato)
                    {
                        return true;
                    }
                    else
                    {
                        if (nodoAct.Elemento < dato)
                        {
                            nodoAct = nodoAct.EnlaceDer;
                        }
                        else
                        {
                            if (nodoAct.Elemento > dato)
                            {
                                nodoAct = nodoAct.EnlaceIzq;
                            }
                        }
                    }
                }
                return false;
            }
        }


        #region Eliminar Incompletos    /// que uno de sus nodos sea null
        public void EliminarIncompletos()  //////////////manda
        {
            EliminarIncomp(raiz);
        }

        public bool PadreIncompleto()
        {
            return PadreIncomp(raiz);
        }
        private bool PadreIncomp(Nodo nodoAct)
        {
            return (nodoAct.enlaceIzq != null && nodoAct.enlaceDer == null || nodoAct.enlaceIzq == null &&
                        nodoAct.enlaceDer != null);
        }
        private void EliminarIncomp(Nodo nodoAct) {
        if(nodoAct==null){
            ///System.out.println("El arbol esta vacio");
        }else{
            if(this.PadreIncomp(nodoAct)){
                if(nodoAct.enlaceDer==null){
                    nodoAct.Elemento = nodoAct.enlaceIzq.elemento;
                    nodoAct.EnlaceIzq = null;
                }else{
                    nodoAct.Elemento = nodoAct.enlaceDer.elemento;
                    nodoAct.EnlaceDer = null;
                }
            }
            
            EliminarIncomp(nodoAct.enlaceDer);
            EliminarIncomp(nodoAct.enlaceIzq);
        }
    }
        # endregion  //

        #region ELIMINAR TODOS LOS NODOS HOJAS(PODAR UN ARBOL)
        public void EliminarHojas()
        {
            ElimHojas(raiz);
        }

        private void ElimHojas(Nodo nodoAct)
        {
            if (nodoAct != null)
            {
                if (esHoja(nodoAct))
                {
                    nodoAct = null;
                }
                else
                {
                    if (esHoja(nodoAct.enlaceIzq))
                    {
                        nodoAct.EnlaceIzq = null;
                    }
                    if (esHoja(nodoAct.enlaceDer))
                    {
                        nodoAct.EnlaceDer = null;
                    }
                    ElimHojas(nodoAct.enlaceIzq);
                    ElimHojas(nodoAct.enlaceDer);
                }
            }
        }

        #endregion

        #region constructor
        public Arbol()
        {
            raiz = new Nodo();
        }
        #endregion
    }
}
