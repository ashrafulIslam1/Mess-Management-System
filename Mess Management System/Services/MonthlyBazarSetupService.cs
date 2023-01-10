using Mess_Management_System.Data;
using Mess_Management_System.Models;
using Mess_Management_System.ViewModels;

namespace Mess_Management_System.Services
{
    public class MonthlyBazarSetupService
    {
        private readonly ApplicationDbContext _dbContext;

        public MonthlyBazarSetupService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(MonthlyBazarSetupViewModel viewModel)
        {
            var model = new MonthlyBazarSetup // here this 'MonthlyBazarSetups' is the main model.
            {
                // Here I assign the viewModel properties to model properties
                HouseRent = viewModel.HouseRent,
                GassBill = viewModel.GassBill,
                BuaBill = viewModel.BuaBill,
                ElectricityBill = viewModel.ElectricityBill,
                WaterBill = viewModel.WaterBill,
                DirtCost = viewModel.DirtCost,
                InternetBill = viewModel.InternetBill,
                Month = viewModel.Month,
                Year = viewModel.Year,
            };

            _dbContext.MonthlyBazarSetups.Add(model); // Here 'MonthlyBazarSetups' is the table name
            _dbContext.SaveChanges();
        }

        public void Update(MonthlyBazarSetupViewModel viewModel)
        {
            var model = _dbContext.MonthlyBazarSetups.Find(viewModel.Id);

            if (model == null)
                throw new Exception();

            model.HouseRent = viewModel.HouseRent;
            model.GassBill = viewModel.GassBill;
            model.BuaBill = viewModel.BuaBill;
            model.ElectricityBill = viewModel.ElectricityBill;
            model.WaterBill = viewModel.WaterBill;
            model.DirtCost = viewModel.DirtCost;
            model.InternetBill = viewModel.InternetBill;
            model.Month = viewModel.Month;
            model.Year = viewModel.Year;

            _dbContext.MonthlyBazarSetups.Update(model);
            _dbContext.SaveChanges();
        }

        public List<MonthlyBazarSetupViewModel> GetAll()
        {
            var query = (from s in _dbContext.MonthlyBazarSetups
                         select new MonthlyBazarSetupViewModel
                         {
                             HouseRent = s.HouseRent,
                             GassBill = s.GassBill,
                             BuaBill = s.BuaBill,
                             ElectricityBill = s.ElectricityBill,
                             WaterBill = s.WaterBill,
                             DirtCost = s.DirtCost,
                             InternetBill = s.InternetBill,
                             Month = s.Month,
                             Year = s.Year,
                         }).AsQueryable();
   
            return query.ToList();
        }

        public MonthlyBazarSetupViewModel? GetById(int id)
        {
            var query = (from s in _dbContext.MonthlyBazarSetups
                         where s.Id == id
                         select new MonthlyBazarSetupViewModel
                         {
                             HouseRent = s.HouseRent,
                             GassBill = s.GassBill,
                             BuaBill = s.BuaBill,
                             ElectricityBill = s.ElectricityBill,
                             WaterBill = s.WaterBill,
                             DirtCost = s.DirtCost,
                             InternetBill = s.InternetBill,
                             Month = s.Month,
                             Year = s.Year,
                         }).SingleOrDefault();

            return query;
        }
    }
}
