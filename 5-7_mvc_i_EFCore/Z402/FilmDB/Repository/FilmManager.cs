using FilmDB.Data;
using FilmDB.Models;

namespace FilmDB.Repository
{
    public class FilmManager
    {
        private readonly ApplicationDbContext _context;

        public FilmManager(ApplicationDbContext context) {  
            _context = context; 
        }

        public async Task<bool> AddFilmAsync(FilmModel filmModel)
        {
            await _context.AddAsync(filmModel);
            await _context.SaveChangesAsync();

            return true;
        }

        public FilmManager RemoveFilm(int id)
        {
            return this;
        }

        public FilmManager UpdateFilm(FilmModel filmModel)
        {
            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            return this;
        }

        public FilmManager GetFilm(int id)
        {
            return null;
        }

        public List<FilmModel> GetFilms()
        {
            return null;
        }
    }
}
