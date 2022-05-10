namespace BASEBALLBIBICOWEB.Models
{
    public class Equipo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        /// <summary>
        /// carreras
        /// </summary>
        public int _Valor { get; set; }
        public int _Out { get; set; }
        public int _CantOutByInning { get; set; }
    }
}
