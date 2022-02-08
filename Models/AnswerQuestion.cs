using System.Collections.Generic;

namespace BASEBALLBIBICOWEB.Models
{
    public class AnswerQuestion
    {
        public int Id { get; set; }

        public Preguntas Pregunta { get; set; }

        public ICollection< Respuestas> Respuesta { get; set; }
    }
}
