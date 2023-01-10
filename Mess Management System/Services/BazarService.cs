using Mess_Management_System.Data;
using Mess_Management_System.Models;
using Mess_Management_System.ViewModels;

namespace Mess_Management_System.Services;
public class BazarService
{
    private readonly ApplicationDbContext _dbcontext;

    public BazarService(ApplicationDbContext dbContext)
    {
        _dbcontext = dbContext;
    }

    public void Create(BazarViewModel viewModel)
    {
        var model = new Bazar
        {
            bazarId = viewModel.bazarId,
            MemberId = viewModel.MemberId,
            Amount = viewModel.Amount,
            Description = viewModel.Description,
            Date = viewModel.Date,
        };
        _dbcontext.Bazars.Add(model);
        _dbcontext.SaveChanges();
    }

    public void Update(BazarViewModel viewModel)
    {
        var model = _dbcontext.Bazars.Find(viewModel.bazarId);

        if (model == null)
            throw new Exception();

        model.MemberId = viewModel.MemberId;
        model.Amount = viewModel.Amount;
        model.Description = viewModel.Description;
        model.Date = viewModel.Date;

        _dbcontext.Bazars.Update(model);
        _dbcontext.SaveChanges();
    }

    public void Delete(int id)
    {
        var model = _dbcontext.Bazars.Find(id);

        if (model == null)
            throw new Exception();

        _dbcontext.Bazars.Remove(model);
        _dbcontext.SaveChanges();
    }

    public List<BazarViewModel> GetAll(int? MemberId, DateTime? fromDate, DateTime? toDate)
    {
        var query = (from b in _dbcontext.Bazars
                     join m in _dbcontext.Members on b.MemberId equals m.MemberId
                     select new BazarViewModel
                     {
                         bazarId = b.bazarId,
                         MemberId = b.MemberId,
                         MemberName = m.Name,
                         Amount = b.Amount,
                         Description = b.Description,
                         Date = b.Date
                     }).AsQueryable();

        if (MemberId != null)
        {
            query = query.Where(b => b.MemberId == (MemberId));
        }

        if (fromDate.HasValue && toDate.HasValue)
        {
            query = query.Where(s => s.Date >= fromDate && s.Date <= toDate);
        }
        else if(fromDate.HasValue)
        {
            query = query.Where(s => s.Date == fromDate);
        }
        //else if (toDate.HasValue)
        //{
        //    query = query.Where(s => s.Date == toDate);
        //}

        return query.ToList();
    }

    public BazarViewModel? GetById(int id)
    {
        var data = (from b in _dbcontext.Bazars
                    where b.bazarId == id
                    select new BazarViewModel
                    {
                        bazarId = b.bazarId,
                        MemberId = b.MemberId,
                        Amount = b.Amount,
                        Description= b.Description,
                        Date= b.Date,
                    }).SingleOrDefault();
        return data;
    }
}
