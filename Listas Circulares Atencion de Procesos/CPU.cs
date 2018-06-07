using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas_Circulares_Atencion_de_Procesos
{
    class CPU
    {
        private Random rdn = new Random();
        Proceso inicio = null;
        Proceso ultimo = null;
        private int colaVacia = 0, proAtendidos = 0, proPendientes = 0, TTotal = 0, faltantes = 0;
        //----------------------------------------------------------------------------------
        public void agregar(Proceso nuevo)
        {
            if (inicio == null)
            {
                inicio = nuevo;
                inicio.sig = inicio;
                ultimo = inicio;
            }
            else
            {
                ultimo.sig = nuevo;
                nuevo.sig = inicio;
                ultimo = nuevo;
            }
        }
        //--------------------------------------------------------------------------------------
        public void start()
        {
            for (int i = 0; i < 300; i++)
            {
                if (probabilidad())
                {
                    agregar(new Proceso(rdn.Next(4, 15)));
                    TTotal++;
                }
                if (inicio != null)
                {
                    inicio.Tiempo -= 1;
                    if (inicio.Tiempo == 0)
                    {
                        eliminar();
                        proAtendidos++;
                    }
                    else
                    {
                        elRotado();
                    }
                }
                else
                {
                    colaVacia++;
                }
            }
            pendientes();
            CiclosPendientes();

        }
        //---------------------------------------------------------------------
        private void pendientes()
        {
            proPendientes = TTotal - proAtendidos;
        }
        //---------------------------------------------------------------------
        public void CiclosPendientes()
        {
            Proceso actual = inicio;
            while (actual.sig == inicio)
            {
                faltantes += actual.Tiempo;
                actual = actual.sig;
            }
        }
        //---------------------------------------------------------------------
        public bool probabilidad()
        {
            int proba = rdn.Next(1, 101);
            if (proba <= 35)
                return true;
            else
                return false;
        }

        public void eliminar()
        {
            inicio = inicio.sig;
            ultimo.sig = inicio;
        }

        public void elRotado()
        {
            ultimo = inicio;
            inicio = inicio.sig;
        }
        //-----------------------------------RETORNAR VALORES---------------------
        public string retornaTotales()
        {
            return TTotal.ToString();
        }
        public string retornaVacias()
        {
            return colaVacia.ToString();
        }
        public string retornaAtendidos()
        {
            return proAtendidos.ToString();
        }
        public string retornaPendientes()
        {
            return proPendientes.ToString();
        }
        public string retornaTiempoPendientes()
        {
            return faltantes.ToString();
        }
    }
}
