using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPILADOR_EXTRACLASE.CACHE
{
    public class Linea
    {
        private int numeroLinea;
        private String contenido;

        private Linea(int numeroLinea, String contenido)
        {
            NumeroLinea = numeroLinea;
            Contenido = contenido;
        }
        public static Linea Crear(int numeroLinea, string contenido)
        {
            return new Linea(numeroLinea, contenido);
        }

        public int NumeroLinea { get => numeroLinea; set => numeroLinea = value; }
        public string Contenido { get => contenido; set => contenido = value; }
    }
}
