namespace BASEBALLBIBICOWEB.Models
{
    public class Respuestas
    {
        public int Id { get; set; }

        public string Respuesta { get; set; }

        public bool IsCorrect { get; set; }

        public Preguntas IdPreguntas { get; set; }

    }
}
