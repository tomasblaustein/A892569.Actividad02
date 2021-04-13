using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> listaDeEquipos;
            listaDeEquipos = new List<string>();
            string equipos = "";

            do
            {
                Console.WriteLine("Ingrese el nombre de su equipo. Escriba 'salir' para continuar.");
                equipos = Console.ReadLine();

                listaDeEquipos.Add(equipos);

            } while (equipos != "salir");

            listaDeEquipos.Remove("salir");

            Console.WriteLine();
            Console.WriteLine("Lista de equipos del torneo:");

            for (int indice = 0; indice < listaDeEquipos.Count; indice++)
            {
                Console.WriteLine($"Equipo Nro {indice + 1}: {listaDeEquipos[indice]}");
            }

            //*****************************************************************************************************

            Console.WriteLine();
            Console.WriteLine("Los partidos del torneo son:");

            for (int indice = 0; indice < listaDeEquipos.Count - 1; indice++)
            {
                for (int indice2 = indice + 1; indice2 < listaDeEquipos.Count; indice2++)
                {
                    Console.WriteLine($"{listaDeEquipos[indice]} vs {listaDeEquipos[indice2]}");
                }
            }

            //*****************************************************************************************************
            Console.WriteLine();

            List<int> listaDePuntos;
            listaDePuntos = new List<int>();

            int ganados = 0;
            int empatados = 0;
            int puntos = 0;

            for (int indice = 0; indice < listaDeEquipos.Count; indice++)
            {
                Console.WriteLine($"-{listaDeEquipos[indice]}");

                Console.Write("Partidos ganados: ");
                if (!int.TryParse(Console.ReadLine(), out ganados))
                {
                    Console.WriteLine("Debe ingresar un número");
                }

                Console.Write("Partidos empatados: ");
                if (!int.TryParse(Console.ReadLine(), out empatados))
                {
                    Console.WriteLine("Debe ingresar un número");
                }

                puntos = (ganados * 3) + empatados;
                Console.WriteLine($"{puntos} pts");

                Console.WriteLine();
                listaDePuntos.Add(puntos);


            }

            Console.WriteLine();

            Dictionary<string, int> puntosTabla = new Dictionary<string, int>() { };

            for (int indice4 = 0; indice4 < listaDePuntos.Count; indice4++)
            {
                puntosTabla.Add(listaDeEquipos[indice4], listaDePuntos[indice4]); //guarda en cada ciclo los puntos y equipos en el diccionario.
            }

            Console.WriteLine("TABLA DE POSICIONES:");

            // https://www.dotnetperls.com/sort-dictionary

            var items = from pair in puntosTabla
                        orderby pair.Value descending
                        select pair;
            foreach (KeyValuePair<string, int> pair in items)
            {
                Console.WriteLine("-" + pair.Key + ": " + pair.Value + "pts.");
            }

            Console.ReadLine();
        }
    }
}
