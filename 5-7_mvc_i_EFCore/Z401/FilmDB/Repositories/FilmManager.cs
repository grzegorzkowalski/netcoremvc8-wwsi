using FilmDB.Data;
using FilmDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FilmDB.Repositories
{
    public class FilmManager
    {
        private readonly ApplicationDbContext _context;
        public FilmManager(ApplicationDbContext context) 
        { 
            _context = context;
        }
        public async Task<FilmManager> AddFilm(FilmModel filmModel)
        {
            try
            {
                await _context.AddAsync(filmModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                filmModel.Id = 0;
                await _context.SaveChangesAsync();
            }


            return this;
        }

        public async Task<FilmManager> RemoveFilm(int id)
        {
            var filmToDelete = _context.Films.SingleOrDefault(x => x.Id == id);

            if (filmToDelete != null) 
            { 
                _context.Films.Remove(filmToDelete);
                await _context.SaveChangesAsync();
            }

            return this;
        }

        public async Task<FilmManager> UpdateFilm(FilmModel filmModel)
        {
            _context.Update(filmModel);
            await _context.SaveChangesAsync();
            return this;
        }

        public async Task<FilmManager> ChangeTitle(int id, string newTitle)
        {
            var filtToEdit = await GetFilm(id);
            if (filtToEdit != null)
            {
                var title = newTitle != null ? newTitle : "Brak tytułu";
                filtToEdit.Title = title;
            }
            await _context.SaveChangesAsync();
            return this;
        }

        public async Task<FilmModel> GetFilm(int id)
        {
            var film = await _context.Films.SingleOrDefaultAsync(x => x.Id == id);
            return film;
        }

        public async Task<List<FilmModel>> GetFilms()
        {
            return await _context.Films.ToListAsync();
        }
    }
}
