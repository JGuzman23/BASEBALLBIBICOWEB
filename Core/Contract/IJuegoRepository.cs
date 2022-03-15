using BASEBALLBIBICOWEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BASEBALLBIBICOWEB.Core.Contract
{
    public  interface IJuegoRepository
    {
        Task<Preguntas> GetPreguntas(string jbase, string level, string libro);
        Task<List<Respuestas>> GetRespuesta(int id);
        Task<List<Preguntas>> GetLibros();
    }
}
