namespace TechnicalExercise.Core.Domain
{
    public class Vehicle : Entity
    {
        public string Color { get; set; }
        public string Type { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid PlateId { get; set; }
        public Plate Plate { get; set; }
    }
}
