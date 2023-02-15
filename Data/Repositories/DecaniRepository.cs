using Microsoft.EntityFrameworkCore;
using UniApi.Interfaces;
using UniApi.Models;

namespace UniApi.Data.Repositories
{
    public class DecaniRepository : IDecaniRepository
    {
        private readonly DecanDbContext _dbcontext;
        public DecaniRepository(DecanDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Decan> CreateDecanAsync(AddDecanRequest addRequest)
        {
            var decan = new Decan()
            {
                Id = new Guid(),
                Nume = addRequest.Nume,
                Prenume = addRequest.Prenume,
                FacultateCondusa = addRequest.FacultateCondusa
            };
            await _dbcontext.Decani.AddAsync(decan);
            await _dbcontext.SaveChangesAsync();
            return decan;
        }

        public async Task<List<Decan>> GetAllDecaniAsync()
        {
            return await _dbcontext.Decani.ToListAsync();
        }

        public async Task<Decan> GetDecanAsync(Guid id)
        {
            return await _dbcontext.Decani.FirstOrDefaultAsync(decan => decan.Id == id);
        }

        public async Task<Decan> UpdateDecanAsync(UpdateDecanRequest updateRequest, Guid id)
        {
            var decan = await _dbcontext.Decani.FindAsync(id);

            decan.Nume = updateRequest.Nume;
            decan.Prenume = updateRequest.Prenume;
            decan.FacultateCondusa = updateRequest.FacultateCondusa;
            await _dbcontext.SaveChangesAsync();

            return await _dbcontext.Decani.FirstOrDefaultAsync(decan => decan.Id == id); ;
        }

        public async Task<Decan> DeleteDecanAsync(Guid id)
        {
            var decan = await _dbcontext.Decani.FindAsync(id);

            if (decan != null)
            {
                _dbcontext.Remove(decan);
                await _dbcontext.SaveChangesAsync();
            }
            return decan;
        }
    }
}
