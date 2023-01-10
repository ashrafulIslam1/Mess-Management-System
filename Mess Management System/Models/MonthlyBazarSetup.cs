using System.ComponentModel.DataAnnotations;

namespace Mess_Management_System.Models
{
    public class MonthlyBazarSetup
    {
        [Key]
        public int Id { get; set; }
        public double HouseRent { get; set; }
        public double GassBill { get; set; }
        public double BuaBill { get; set; }
        public double ElectricityBill { get; set; }
        public double InternetBill { get; set; }
        public double WaterBill { get; set; }
        public double DirtCost { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
    }
}
