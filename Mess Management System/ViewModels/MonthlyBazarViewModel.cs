using System.ComponentModel.DataAnnotations;

namespace Mess_Management_System.ViewModels
{
    public class MonthlyBazarViewModel
    {
        [Key]
        public int? Id { get; set; }
        public int? MemberId { get; set; }
        public string? Name { get; set; }
        public double HouseRent { get; set; }
        public double GassBill { get; set; }
        public double BuaBill { get; set; }
        public double ElectricityBill { get; set; }
        public double InternetBill { get; set; }
        public double WaterBill { get; set; }
        public double DirtCost { get; set; }
        public double FoodCost { get; set; }
        public int? TotalMeal { get; set; }
        public double? PerviousDue { get; set; }
        public double? PersonalLoan { get; set; }
        public double? TotalCost { get; set; }
        public double? TotalBazarCost { get; set; }
        public double? TotalPayableCost { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
    }
}
