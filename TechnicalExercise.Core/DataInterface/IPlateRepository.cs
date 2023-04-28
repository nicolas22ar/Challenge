using TechnicalExercise.Core.Domain;

namespace TechnicalExercise.Core.DataInterface
{
    public interface IPlateRepository
    {
        Task<IEnumerable<Plate>> GetAvailablePatesAsync(DateTime date);
    }
}
