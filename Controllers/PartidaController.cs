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
        string libroSeleccionado ="";
        string modoSeleccionado ="";
        Carrera info = new Carrera();
        readonly IJuegoRepository _juegoRepository;

        public int idpregunta { get; set; }

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
            var outs = jugadas.Carrera._Out;
            var carreras = jugadas.Carrera._Valor; 

            var equipos = MultiplayerService.Equipos;
            
           
            ViewBag.inning = jugadas.innings.Value;
            ViewBag.equipos = equipos;
            ViewBag.outs = outs;
            ViewBag.carrerasAnotadas = carreras;

            return View(result);
        }

        public async Task<IActionResult> Preguntas(Categoria model)
        {

            var result = await _juegoRepository.GetPreguntas(model.Jbase,modoSeleccionado,libroSeleccionado);
            if (result == null)
            {
                return RedirectToAction("Juego");
            }
            var respuestaCorecte = await _juegoRepository.GetRespuestaCorrecta(result.Id);
            var respuesta = await _juegoRepository.GetRespuestas(result.Id);

           

            ViewBag.question= result.Pregunta;
            ViewBag.bateo = model.Jbase;
            ViewBag.idPregunta = result.Id;
            idpregunta = result.Id;
            ViewBag.RespuestaCorrecta = respuestaCorecte.Respuesta;

            return View(respuesta);
        }

        public async Task<IActionResult> Custom()
        {
            var result = await _juegoRepository.GetLibros();
            return View(result);
        }

        public IActionResult MultiPlayer(Equipo equipo, bool single )
        {
            

            if (single)
            {
                ViewBag.title = "Single Player";
               
            }
            else
            {
                ViewBag.title = "Multi-Player";
            }

            MultiplayerService.multijugador(equipo,single);
            var equipos = MultiplayerService.Equipos;
           
           
            if (MultiplayerService.IsComplete )
            {
                equipos.RemoveAt(0);
                return RedirectToAction("GeneralOrCustom");
            }
            if (equipos.Count == 2)
            {
                return View("Rival");
            }
            
           return View();
   
        }

        public IActionResult GeneralOrCustom()
        {
            return View();
        }

        public IActionResult Respuesta(bool id, string jBase, int idPregunta, string respuestaC)
        {

          
                _juegoRepository.MarcarPregunta(idPregunta);
            
            RespuestaService.Respuesta(id, jBase, outs);
            var valor = RespuestaService.ValorBase;
            var respuesta = RespuestaService.ValorRespuesta;
            var equipos = MultiplayerService.Equipos;
           
            var Outs = RespuestaService.Outs;
            
            jugadas.JugadorBatea(new Categoria { Jbase = jBase, Valor= valor }, Outs, equipos);

            if (jugadas.Ganador)
            {

                ViewBag.respuesta = jugadas.nombreGanador;
                ViewBag.vueltas = jugadas.Vuelta;
                _juegoRepository.ReiniciarJuego();

            }
            else
            {
                ViewBag.respuesta = respuesta;
                ViewBag.posiciones = posicion;
                
            }

            if (!id)
            {
                ViewBag.RespuestaCorrecta = respuestaC;
            }
           
            return View();
        }

    


    }
}
