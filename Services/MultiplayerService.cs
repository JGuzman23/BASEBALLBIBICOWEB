using BASEBALLBIBICOWEB.Models;
using System.Collections.Generic;
using System.Linq;

namespace BASEBALLBIBICOWEB.Services
{


    public class MultiplayerService
    {

        public static List<Equipo> Equipos { get; set; }
        public static bool IsComplete = false;
        
        public static void multijugador(Equipo equipo)
        {
            if (Equipos == null)
                Equipos = new List<Equipo>();


            if (!Equipos.Any())
            {
               
                Equipos.Add(equipo);
             

            }
            else
            {

                Equipos.Add(equipo);
                if (Equipos.Count == 3)
                {
                    IsComplete = true;
                }
               
            }

            

        }

    }
}
