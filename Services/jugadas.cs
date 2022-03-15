using BASEBALLBIBICOWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BASEBALLBIBICOWEB.Services
{
    public class jugadas
    {
        public static List<Categoria> Categorias { get; set; }

        public static Carrera Carrera = new Carrera();

         public static Innings innings = new Innings();

        public static void JugadorBatea(Categoria categoria, int outs)
        {
            if (Categorias == null)
                Categorias = new List<Categoria>();



            categoria.NumeroJugador = new Random().Next(1, 1000);
            
            if(outs==0)
            {
                
                if (!Categorias.Any())
                {
                    Categorias.Add(categoria);
                }
                else
                {
                    Categorias.ForEach(catego =>
                    {
                        catego.Valor = (catego.Valor + categoria.Valor);
                    });

                    Categorias.Add(categoria);
                    var carrerasAnotadas = Categorias.Where(x => x.Valor > 3);
                    Carrera.Valor += carrerasAnotadas.Count();
                    Categorias.RemoveAll(x => x.Valor > 3);

                }
            }
            else
            {
                Carrera.Out += outs;
                Carrera.CantOutByInning += outs;
                if (Carrera.CantOutByInning ==6)
                {
                    innings.Value++;
                    
                }
                if (Carrera.Out >2)
                {
                    Carrera.Out=0;
                    Categorias.Clear();
                }
            }
            
           

        }
    }
}
