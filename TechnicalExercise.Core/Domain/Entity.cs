using System.ComponentModel.DataAnnotations;

namespace TechnicalExercise.Core.Domain
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
