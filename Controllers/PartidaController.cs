using BASEBALLBIBICOWEB.Core.Contract;
using BASEBALLBIBICOWEB.Models;
using BASEBALLBIBICOWEB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BASEBALLBIBICOWEB.Controllers
{
    public class PartidaController : Controller
    {
        int posicion=0;
        int outs = 0;
        string libroSeleccionado;
        string modoSeleccionado;
        Carrera info = new Carrera();
        readonly IJuegoRepository _juegoRepository;


        public PartidaController(IJuegoRepository juegoRepository)
        {
            _juegoRepository=juegoRepository;
        }

        public IActionResult Partida()
        {
            return View();
        }

        public IActionResult Modalidad(string libro)
        {
            libroSeleccionado= libro;
            return View();
        }

        public IActionResult Juego()

        {
            var result = jugadas.Categorias;
            var outs = jugadas.Carrera.Out;
            var carreras = jugadas.Carrera.Valor; ;
           
            
            ViewBag.outs = outs;
            ViewBag.inning = jugadas.innings.Value;

            ViewBag.carrerasAnotadas = carreras;

            return View(result);
        }
        

        public async Task<IActionResult> Preguntas(Categoria model)
        {

            var result = await _juegoRepository.GetPreguntas(model.Jbase,modoSeleccionado,libroSeleccionado);

            if (result==null)
            {
                return RedirectToAction("Juego");
            }

            ViewBag.question= result.Pregunta;
            ViewBag.bateo = model.Jbase;

            var respuesta = await _juegoRepository.GetRespuesta(result.Id);

            return View(respuesta);
        }

        public async Task<IActionResult> Custom()
        {
            var result = await _juegoRepository.GetLibros();
            return View(result);
        }

        public IActionResult MultiPlayer()
        {
            return View();
        }

        public IActionResult GeneralOrCustom()
        {
            return View();
        }

        public IActionResult Respuesta(bool id, string jBase)
        {

            int valor = 0;
            ViewBag.value = id;
            ViewBag.posiciones = posicion;
            if (id==false)
            {
                outs =1;
            }
            else
            {
                switch (jBase)
                {
                    case "HIT":
                        valor =1;
                        break;
                    case "DOBLE":
                        valor =2;
                        break;
                    case "TRIPLE":
                        valor =3;
                        break;
                    case "HOMERUM":
                        valor =4;
                        break;

                    default:
                        break; 
                }
            }

            jugadas.JugadorBatea(new Categoria { Jbase = jBase, Valor= valor }, outs);

            return View();
        }


    }
}
