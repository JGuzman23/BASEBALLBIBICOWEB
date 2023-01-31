using BASEBALLBIBICOWEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BASEBALLBIBICOWEB.Core.Contract
{
    public  interface IJuegoRepository
    {
        Task<Preguntas> GetPreguntas(string jbase, string level, string libro);
        Task<List<Respuestas>> GetRespuestas(int id);
        Task<Respuestas> GetRespuestaCorrecta(int id);
        Task<List<Preguntas>> GetLibros();
        Task<Respuestas> MarcarPregunta(int id);
        Task<Respuestas> ReiniciarJuego();
    }
}
