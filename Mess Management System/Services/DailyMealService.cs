using Mess_Management_System.Data;
using Mess_Management_System.Models;
using Mess_Management_System.ViewModels;

namespace Mess_Management_System.Services;

public class DailyMealService
{
    // here I initialize an object (_dbContext) where I store all the data from database table.
    private readonly ApplicationDbContext _dbContext;

    public DailyMealService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(DailyMealViewModel viewModel)
    {
        var model = new DailyMeal // here this 'Attendance' is the main model.
        {
            // Here I assign the viewModel properties to model properties
            MealId = viewModel.MealId,
            MemberId = viewModel.MemberId,
            Breakfast = viewModel.Breakfast,
            Lunch = viewModel.Lunch,
            Dinner = viewModel.Dinner,
            Date = viewModel.Date,
        };
        
        _dbContext.DailyMeals.Add(model); // Here 'Attendancse' is the table name
        _dbContext.SaveChanges();
    }

    public void Update(DailyMealViewModel viewModel)
    {
        var model = _dbContext.DailyMeals.Find(viewModel.MealId);

        if (model == null)
            throw new Exception();

        model.MealId = viewModel.MealId;
        model.MemberId = viewModel.MemberId;
        model.Breakfast = viewModel.Breakfast;
        model.Lunch = viewModel.Lunch;
        model.Dinner = viewModel.Dinner;
        model.Date = viewModel.Date;

        _dbContext.DailyMeals.Update(model);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var model = _dbContext.DailyMeals.Find(id);
        if (model == null)
            throw new Exception();

        _dbContext.DailyMeals.Remove(model);
        _dbContext.SaveChanges();
    }

    public List<DailyMealViewModel> GetAll(DateTime? fromDate, DateTime? toDate, int? MemberId)
    {         
        var query = (from s in _dbContext.DailyMeals
                     join e in _dbContext.Members on s.MemberId equals e.MemberId
                     orderby s.Date
                     select new DailyMealViewModel
                     {
                         MealId = s.MealId,
                        MemberId = s.MemberId,
                        MemberName = e.Name,
                        Date = s.Date,
                        Lunch = s.Lunch,
                        Dinner = s.Dinner,
                        Breakfast = s.Breakfast,
                        //Status = s.InTime == DateTime.MinValue || s.OutTime == DateTime.MinValue ? 0 : 1
                        // query.Where(x => x.Status == 1).Count();
                     }).AsQueryable();

        if (MemberId != null)
        {
            query = query.Where(s => s.MemberId == (MemberId));
        }
        if (fromDate.HasValue && toDate.HasValue)
        {
            query = query.Where(s => s.Date >= fromDate && s.Date <= toDate);
        }
        return query.ToList();
    }

    public DailyMealViewModel? GetById(int id)
    {
        var data = (from s in _dbContext.DailyMeals
                    where s.MealId == id
                    select new DailyMealViewModel
                    {
                        MealId = s.MealId,
                        MemberId = s.MemberId,
                        //EmployeeName = s.EmployeeName,
                        Date = s.Date,
                        Lunch = s.Lunch,
                        Dinner = s.Dinner,
                        Breakfast = s.Breakfast,
                    }).SingleOrDefault();
        return data;
    }
}
