using BASEBALLBIBICOWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BASEBALLBIBICOWEB.Services
{
    public class jugadas
    {
        public static List<Categoria> Categorias { get; set; }

        public static Equipo Carrera = new Equipo();

        public static Innings innings = new Innings();

        public static int nunEquipos { get; set; }

        public static bool Ganador { get; set; }

        public static int Vuelta { get; set; }
        public static string nombreGanador { get; set; }

        public static void JugadorBatea(Categoria categoria, int outs, List<Equipo> equipos)
        {


            if (Categorias == null)
                Categorias = new List<Categoria>();


            categoria.NumeroJugador = new Random().Next(1, 1000);
            if (outs != 0)
            {
                Carrera._Out += outs;
                Carrera._CantOutByInning += outs;
                if (Carrera._CantOutByInning == 6)
                {
                    innings.Value++;
                    Carrera._CantOutByInning = 0;

                }
                if (Carrera._Out > 2)
                {
                    if (nunEquipos == 0)
                    {
                        nunEquipos = 1;
                    }
                    else
                    {
                        nunEquipos = 0;
                    }

                    Carrera._Valor = 0;
                    Carrera._Out = 0;
                    Categorias.Clear();
                }

            }
            else
            {

                if (!Categorias.Any())
                {
                    Categorias.Add(categoria);
                    if (categoria.Valor == 4)
                    {
                        Carrera.Name = equipos.ElementAt(nunEquipos).Name;
                        var carrerasAnotadas = Categorias.Where(x => x.Valor > 3);

                        //Carrera._Valor += carrerasAnotadas.Count();

                        equipos.ElementAt(nunEquipos)._Valor += carrerasAnotadas.Count();


                        Categorias.RemoveAll(x => x.Valor > 3);
                    }
                }
                else
                {
                    Categorias.ForEach(catego =>
                    {
                        catego.Valor = (catego.Valor + categoria.Valor);
                    });

                    Categorias.Add(categoria);
                    var carrerasAnotadas = Categorias.Where(x => x.Valor > 3);

                    //Carrera._Valor += carrerasAnotadas.Count();
                    Carrera.Name = equipos.ElementAt(nunEquipos).Name;

                    equipos.ElementAt(nunEquipos)._Valor += carrerasAnotadas.Count();
                    Categorias.RemoveAll(x => x.Valor > 3);


                }
            }
            LogicInnin(innings.Value, Carrera._CantOutByInning, equipos);

        }
        public static void LogicInnin(int inning, int outs, List<Equipo> equipos)
        {
            //Aqui se aplicara la logica los innin
            // Si el innin es mayor que 5, el equipo con mas carreras gana
            // Si el equipo que no es home club tiene menos carrera al terminar
            // su inning # 5, el equipo contrario gana
            var carrreras_nunEquipoCero = equipos.ElementAt(0)._Valor;
            var carrreras_nunEquipoUno = equipos.ElementAt(1)._Valor;

            if (inning >= 5 && outs >= 6 && (carrreras_nunEquipoCero > carrreras_nunEquipoUno))
            {
                //aqui llama a la vista y presenta el equipo ganador
                //equipo cero es el ganador


                Ganador = true;
                Vuelta = carrreras_nunEquipoCero ;
                nombreGanador = equipos.ElementAt(0).Name;


            }

            if (inning >= 5 && outs >= 3 && (carrreras_nunEquipoCero < carrreras_nunEquipoUno))
            {
                //aqui llama a la vista y presenta el equipo ganador
                //el equipo uno es el ganador

                Ganador = true;
                Vuelta = carrreras_nunEquipoUno;
                nombreGanador = equipos.ElementAt(1).Name;
            }
        }

    }
}
