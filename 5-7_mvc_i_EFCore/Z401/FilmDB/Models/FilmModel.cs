using System.ComponentModel.DataAnnotations;

namespace FilmDB.Models
{
    public class FilmModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
    }
}
