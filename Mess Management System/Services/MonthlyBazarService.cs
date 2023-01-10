using Mess_Management_System.Data;
using Mess_Management_System.Models;
using Mess_Management_System.ViewModels;

namespace Mess_Management_System.Services
{
    public class MonthlyBazarService
    {
        private readonly ApplicationDbContext _dbContext;

        public MonthlyBazarService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Generate(MonthlyBazarViewModel vm)
        {
            var existingMonthlyBill = _dbContext.MonthlyBazars.Where(x => x.Month == vm.Month && x.Year == vm.Year).ToList();
            if (existingMonthlyBill.Count > 0)
            {
                _dbContext.MonthlyBazars.RemoveRange(existingMonthlyBill);
            }

            var member = _dbContext.Members.ToList();

            var individualMeal = (from s in _dbContext.DailyMeals
                              where s.Date.Year == vm.Year && s.Date.Month == vm.Month
                              group s by s.MemberId into c
                              select new
                              {
                                  MemberId = c.Key,
                                  Breakfast = c.Sum(x => x.Breakfast),
                                  Lunch = c.Sum(x => x.Lunch),
                                  Dinner = c.Sum(x => x.Dinner),
                                  TotalMeal = c.Sum(x => x.Breakfast + x.Lunch + x.Dinner)
                              }).ToList();

            int totameal = individualMeal.Sum(x => x.TotalMeal);

            var bazar = (from b in _dbContext.Bazars
                         where b.Date.Year == vm.Year && b.Date.Month == vm.Month
                         group b by b.MemberId into c
                         select new
                         {
                             MemberId = c.Key,
                             Bazar = c.Sum(x => x.Amount)
                         }).ToList();

            double totalBazars = bazar.Sum(x => x.Bazar);            

            var data = (from e in member
                        from mb in _dbContext.MonthlyBazarSetups where mb.Month == vm.Month && mb.Year == vm.Year
                        join a in individualMeal on e.MemberId equals a.MemberId
                        join b in bazar on e.MemberId equals b.MemberId
                        select new
                        {
                            MemberId = e.MemberId,
                            Breakfast = a.Breakfast,
                            Lunch = a.Lunch,
                            Dinner = a.Dinner,
                            personTotalMeal = a.TotalMeal,
                            personTotalBazar = b.Bazar,
                            GassBill = mb.GassBill / member.Count,
                            BuaBill = mb.BuaBill / member.Count,
                            ElectricityBill = mb.ElectricityBill / member.Count,
                            HouseRent = mb.HouseRent / member.Count,
                            DirtCost = mb.DirtCost / member.Count,
                            WaterBill = mb.WaterBill / member.Count,
                            InternetBill = mb.InternetBill / member.Count,
                            foodCost = (totalBazars / totameal) * a.TotalMeal,
                        }).ToList();

            foreach(var item in data)
            {
                _dbContext.MonthlyBazars.Add(new MonthlyBazar
                {
                    MemberId = item.MemberId,
                    Year = vm.Year,
                    Month = vm.Month,
                    GassBill = Math.Round(item.GassBill, 2),
                    BuaBill = Math.Round(item.BuaBill, 2),
                    ElectricityBill = Math.Round(item.ElectricityBill, 2),
                    HouseRent = Math.Round(item.HouseRent, 2),
                    DirtCost = Math.Round(item.DirtCost, 2),
                    WaterBill = Math.Round(item.WaterBill, 2),
                    InternetBill = Math.Round(item.InternetBill, 2),
                    TotalBazarCost = Math.Round(item.personTotalBazar, 2),
                    TotalMeal = item.personTotalMeal,
                    FoodCost = Math.Round(item.foodCost, 2),
                    PersonalLoan = 0,
                    PerviousDue = 0,
                    TotalCost = Math.Round((item.GassBill + item.BuaBill + item.ElectricityBill + item.HouseRent + item.DirtCost + item.WaterBill + item.InternetBill
                    + item.foodCost), 2),
                    TotalPayableCost = Math.Round((item.GassBill + item.BuaBill + item.ElectricityBill + item.HouseRent + item.DirtCost + item.WaterBill + item.InternetBill
                    + item.foodCost) - item.personTotalBazar, 2),
                });
            }
            _dbContext.SaveChanges();
        }
        public List<MonthlyBazarViewModel> GetAll()
        {
            var query = (from b in _dbContext.MonthlyBazars
                         join m in _dbContext.Members on b.MemberId equals m.MemberId
                         select new MonthlyBazarViewModel
                         {
                             Year = b.Year,
                             Month = b.Month,
                             Name = m.Name,
                             GassBill = b.GassBill,
                             BuaBill = b.BuaBill,
                             ElectricityBill = b.ElectricityBill,
                             HouseRent = b.HouseRent,
                             DirtCost = b.DirtCost,
                             WaterBill = b.WaterBill,
                             InternetBill = b.InternetBill,
                             TotalMeal = b.TotalMeal,
                             TotalBazarCost = b.TotalBazarCost,
                             TotalCost = b.TotalCost,
                             TotalPayableCost = b.TotalPayableCost,
                             FoodCost = b.FoodCost,
                             PersonalLoan = b.PersonalLoan,
                             PerviousDue = b.PerviousDue,
                         }).AsQueryable();

            return query.ToList();
        }

    }
}
