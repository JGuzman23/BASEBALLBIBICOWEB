using BASEBALLBIBICOWEB.Core.Contract;
using BASEBALLBIBICOWEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BASEBALLBIBICOWEB.Controllers
{
    public class PartidaController : Controller
    {

        readonly IJuegoRepository _juegoRepository;

        public PartidaController(IJuegoRepository juegoRepository)
        {
            _juegoRepository=juegoRepository;
        }
        int posicion;

        public IActionResult Partida()
        {
            return View();
        }

        public IActionResult Modalidad()
        {
            return View();
        }

        public IActionResult Juego()

        {

            return View();
        }

        
        public async Task<IActionResult> Preguntas(Base model)
        {

            
            var result = await _juegoRepository.GetPreguntas(model.Jbase);

            if (result==null)
            {
                return RedirectToAction("Juego");
            }

            ViewBag.question= result.Pregunta;
            ViewBag.bateo = model.Jbase;

            var respuesta = await _juegoRepository.GetRespuesta(result.Id);

            return View(respuesta);
        }

        public async Task< IActionResult> Custom()
        {
            var result =await _juegoRepository.GetLibros();
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

        public IActionResult Respuesta(bool id,string jBase )
        {
            
            
            ViewBag.value = id;
            ViewBag.posiciones = posicion;


            if (id==true)
            {
                switch (jBase)
                {
                    case "HIT":
                        posicion=1;
                        break;

                    case "DOBLE":
                        posicion=2;
                        break;
                    case "TRIPLE":
                        posicion=3;
                        break;
                    case "HOMERUM":
                        posicion=4;
                        break;
                    default:
                        break;
                }
            }
            


            return View();
        }


    }
}
