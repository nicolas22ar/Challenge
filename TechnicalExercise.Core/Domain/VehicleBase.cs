namespace TechnicalExercise.Core.Domain
{
    public class VehicleBase
    {
        public string Color { get; set; }
        public string Type { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid PlateId { get; set; }
        
    }
}
