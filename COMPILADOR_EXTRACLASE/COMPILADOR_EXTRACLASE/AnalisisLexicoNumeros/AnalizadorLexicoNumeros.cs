using COMPILADOR_EXTRACLASE.CACHE;
using COMPILADOR_EXTRACLASE.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPILADOR_EXTRACLASE.AnalisisLexicoNumeros
{
    public class AnalizadorLexicoNumeros
    {


        private int numeroLineaActual = 0;
        private string contenidoLineaActual = "";
        private int puntero = 0;
        private string caracterActual = "";
        private string lexema = "";
        private string Categoria = "";
        private string estadoActual = "";
        private int posicionInicial = 0;
        private int posicionFinal = 0;
        private bool continuarAnalisis = false;

        public AnalizadorLexicoNumeros()
        {
            CargarNuevaLinea();
        }



        private void CargarNuevaLinea()
        {
            if (!"@eof@".Equals(contenidoLineaActual))
            {
                numeroLineaActual += 1;
                contenidoLineaActual = DataCache.ObtenerLinea(numeroLineaActual).Contenido;
                numeroLineaActual = DataCache.ObtenerLinea(numeroLineaActual).NumeroLinea;
                puntero = 1;
            }


        }

        private void LeerSiguienteCaracter()
        {
            if (!"@eof@".Equals(contenidoLineaActual))
            {
                caracterActual = "@eof@";
            }
            else if (puntero > contenidoLineaActual.Length)
            {
                caracterActual = "@eof@";
            }
            else
            {
                caracterActual = contenidoLineaActual.Substring(puntero - 1, 1);
                puntero = puntero + 1;

            }

            //PARA VER RESULTADOS
            while ("@EOF".Equals(caracterActual))
            {
                DevolverSiguienteComponente();
            }

        }

        private void DevolverPuntero()
        {
            puntero -= 1;

        }
        private void Concatenar()
        {
            lexema += caracterActual;

        }

        private void Resetear()
        {
            estadoActual = "q0";
            lexema = "";
            Categoria = "";
            posicionInicial = 0;
            posicionFinal = 0;
            caracterActual = "";
            continuarAnalisis = true;
        }


        public void DevolverSiguienteComponente()
        {
            Resetear();
            while (continuarAnalisis)
            {
                if ("q0".Equals(estadoActual))
                {
                    ProcesarEstado0();
                }else if ("q1".Equals(estadoActual)) {

                    ProcesarEstado1();
                
                }else if ("q2".Equals(estadoActual))
                {
                    ProcesarEstado2();
                }
                else if ("q3".Equals(estadoActual))
                {
                    ProcesarEstado3();
                }
                else if ("q4".Equals(estadoActual))
                {
                    ProcesarEstado4();
                }
                else if ("q5".Equals(estadoActual))
                {
                    ProcesarEstado5();
                }

            }
        }


        private void ProcesarEstado0()
        {
            DevorarEspacionBlanco();
           if (UtilTexto.EsDigito(caracterActual))
            {
                estadoActual = "q1";

            }
            else if (UtilTexto.EsFinlinea(caracterActual))
            {
                estadoActual = "q4";

            }
            else if (UtilTexto.EsFinArchivo(caracterActual))
            {
                estadoActual = "q5";

            }

        }

        private void ProcesarEstado1()
        {
            Concatenar();
            LeerSiguienteCaracter();

            if (UtilTexto.EsDigito(caracterActual))
            {
                estadoActual = "q2";
            }
            else
            {

                estadoActual = "q3";
            }

        }

        private void ProcesarEstado2()
        {
            Concatenar();
            LeerSiguienteCaracter();

            if (UtilTexto.EsEspacio(caracterActual))
            {
                estadoActual = "q0";
            }
            else
            {

                estadoActual = "q3";
            }

        }
        private void ProcesarEstado3()
        {
            DevolverPuntero();
            Categoria = "ERROR NUMERO NO VALIDO";
            FormarCamponenteLexico();
            continuarAnalisis = false;

        }

        private void ProcesarEstado4()
        {
            DevolverPuntero();
            Categoria = "FIN LINEA";
            FormarCamponenteLexico();
            continuarAnalisis = false;
        }

        private void ProcesarEstado5()
        {
            CargarNuevaLinea();
            Resetear();
            lexema = "@EOF@";
        }



        private void FormarCamponenteLexico()
        {
            posicionInicial = puntero - lexema.Length;
            posicionFinal = puntero - 1;

            Console.WriteLine("Categoria: " + Categoria);
            Console.WriteLine("lexema: " + lexema);
            Console.WriteLine("Numero Linea: " + numeroLineaActual);
            Console.WriteLine("Posicion Inicial: " + posicionInicial);
            Console.WriteLine("Posicion Final: " + posicionFinal);


        }

        private void DevorarEspacionBlanco()
        {
            while ("".Equals(caracterActual.Trim()) || "    ".Equals(caracterActual))
            {
                LeerSiguienteCaracter();
            }
        }
    }
}
