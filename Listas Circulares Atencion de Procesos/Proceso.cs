using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas_Circulares_Atencion_de_Procesos
{
    class Proceso
    {
        private int _tiempo;
        private Proceso _siguiente;

        public Proceso(int tiempo)
        {
            this._tiempo = tiempo;
        }

        public int Tiempo
        {
            set { _tiempo = value; }
            get { return _tiempo; }
        }

        public Proceso sig
        {
            set { _siguiente = value; }
            get { return _siguiente; }
        }
    }
}
