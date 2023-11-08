using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletroHogar.Utils
{
    internal class ConsolaUtils
    {
        public static void DibujarTitulo(string titulo)
        {
            Console.Clear();
            string separador = "";
            string separadorTitulo = "";
            int cantidadMaxima = 0;

            if (titulo.Length % 2 == 0)
            {
                cantidadMaxima = 64;
            }
            else
            {
                cantidadMaxima = 63;
            }

            for (int i = 0; i < cantidadMaxima + 2; i++)
            {
                separador = separador + "-";
            }

            for (int i = 0; i < (cantidadMaxima - titulo.Length) / 2; i++)
            {
                separadorTitulo = separadorTitulo + "-";
            }


            Console.WriteLine(separador);
            Console.WriteLine(separadorTitulo + " " + titulo + " " + separadorTitulo);
            Console.WriteLine(separador);
        }
        public static bool EsOpcionValida(string opcion, string[] opcionesValidas)
        {
            foreach (string o in opcionesValidas)
            {
                if (o.ToUpper() == opcion.ToUpper())
                {
                    return true;
                }
            }

            return false;
        }

        public static string PedirString(string msg)
        {
            Console.WriteLine("Ingrese " + msg);
            string valor = Console.ReadLine();

            //Validaciones
            return valor;
        }

        public static int PedirInt(string msg)
        {
            Console.WriteLine("Ingrese " + msg);
            int valor = int.Parse(Console.ReadLine());

            //Validaciones
            return valor;
        }

        public static DateTime PedirFecha(string msg)
        {
            Console.WriteLine("Ingrese fecha " + msg + " con el formato YYYY-MM-DD");
            DateTime valor = Convert.ToDateTime(Console.ReadLine());

            //Validaciones
            return valor;
        }

        public static double PedirDouble(string msg)
        {
            Console.WriteLine("Ingrese " + msg);
            double valor = double.Parse(Console.ReadLine());

            //Validaciones
            return valor;
        }
    }
}
