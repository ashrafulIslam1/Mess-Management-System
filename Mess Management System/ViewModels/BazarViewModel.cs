using System.ComponentModel.DataAnnotations;

namespace Mess_Management_System.ViewModels
{
    public class BazarViewModel
    {
        public int bazarId { get; set; }
        public int MemberId { get; set; }
        [Display(Name = "Member Name")]
        public string? MemberName { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
