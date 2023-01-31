namespace BASEBALLBIBICOWEB.Models
{
    public class Equipo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        /// carreras
        public int _Valor { get; set; }
        public int _Out { get; set; }
        public int _CantOutByInning { get; set; }
    }
}
