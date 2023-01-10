using Mess_Management_System.Data;
using Mess_Management_System.Models;
using Mess_Management_System.ViewModels;

namespace Mess_Management_System.Services;

public class MemberListService
{
    private readonly ApplicationDbContext _context;

    public MemberListService (ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(MemberListViewModel viewModel)
    {
        var model = new MemberList
        {
            MemberId = viewModel.MemberId,
            Name = viewModel.Name,
            CurrentAddress = viewModel.CurrentAddress,
            PermanentAddress = viewModel.PermanentAddress,
            Email = viewModel.Email,
            Contact = viewModel.Contact,
        };
        _context.Members.Add(model);
        _context.SaveChanges();
    }

    public void Update(MemberListViewModel viewModel)
    {
        var model = _context.Members.Find(viewModel.MemberId);

        if(model == null)
            throw new Exception();

        model.Name = viewModel.Name;
        model.CurrentAddress = viewModel.CurrentAddress;
        model.PermanentAddress = viewModel.PermanentAddress;
        model.Email = viewModel.Email;
        model.Contact = viewModel.Contact;

        _context.Members.Update(model);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var model = _context.Members.Find(id);

        if (model == null)
            throw new Exception();

        _context.Members.Remove(model);
        _context.SaveChanges();
    }

    public List<MemberListViewModel> GetAll(string searchString)
    {
        var query = (from m in _context.Members 
                     select new MemberListViewModel
                     {
                         MemberId = m.MemberId,
                         Name = m.Name,
                         CurrentAddress = m.CurrentAddress,
                         PermanentAddress = m.PermanentAddress,
                         Email = m.Email,
                         Contact = m.Contact,
                     }).AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
        {
            query = query.Where(s => s.Name.Contains(searchString));
        }

        return query.ToList();
    }

    public MemberListViewModel? GetById(int id)
    {
        var data = (from m in _context.Members
                    where m.MemberId == id
                    select new MemberListViewModel
                    {
                        MemberId=m.MemberId,
                        Name = m.Name,
                        Contact = m.Contact,
                        CurrentAddress = m.CurrentAddress,
                        PermanentAddress = m.PermanentAddress,
                        Email= m.Email,
                    }).SingleOrDefault();
        return data;
    }

    public List<DropDownViewModel> GetDropDown()
    {
        var data = (from m in _context.Members
                    select new DropDownViewModel
                    {
                        Value = m.MemberId,
                        Text = m.Name,
                    }).ToList();

        return data;
    }

}
