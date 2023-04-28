using Microsoft.EntityFrameworkCore;
using TechnicalExercise.Core.Data;
using TechnicalExercise.Core.DataInterface;
using TechnicalExercise.Core.Domain;

namespace TechnicalExercise.Core.DataAccess
{
    public class PlateRepository : IPlateRepository
    {
        private readonly TestDataContext _context;

        public PlateRepository(TestDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Plate>> GetAvailablePatesAsync(DateTime date)
        {
            return await _context
                    .Plates
                    .AsNoTracking()
                    .Where(x => x.Date >= date)
                    .ToListAsync();
        }
    }
}
