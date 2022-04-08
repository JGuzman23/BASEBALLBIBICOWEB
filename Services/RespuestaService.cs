namespace BASEBALLBIBICOWEB.Services
{
    public class RespuestaService
    {
        public static string ValorRespuesta { get; set; }
        public static int ValorBase { get; set; }
        public static int Outs { get; set; }

        public static void Respuesta( bool id, string jBase, int outs)
        {
            Outs=outs;
            if (id == false)
            {
                Outs = 1;
                ValorRespuesta = "Incorrecto!";
            }
            else
            {
               ValorRespuesta = "Correcto!!!";
                switch (jBase)
                {
                    case "HIT":
                        ValorBase = 1;
                        break;
                    case "DOBLE":
                        ValorBase = 2;
                        break;
                    case "TRIPLE":
                        ValorBase = 3;
                        break;
                    case "HOMERUM":
                        ValorBase = 4;
                        break;

                    default:
                        break;
                }
            }

        }
    }
}
