using COMPILADOR_EXTRACLASE.AnalisisLexicoNumeros;
using COMPILADOR_EXTRACLASE.CACHE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPILADOR_EXTRACLASE
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataCache.AgregarLinea("");
            DataCache.AgregarLinea("23 45 23 66 12");
            DataCache.AgregarLinea("11 32 72");
            AnalizadorLexicoNumeros analex = new AnalizadorLexicoNumeros();
            analex.DevolverSiguienteComponente();
        }
    }
}
