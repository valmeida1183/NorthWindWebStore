namespace NorthWind.Domain.Entities
{
    public class EmployeeTerritory
    {
        public EmployeeTerritory()
        {

        }

        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Territory Territory { get; set; }
    }
}
