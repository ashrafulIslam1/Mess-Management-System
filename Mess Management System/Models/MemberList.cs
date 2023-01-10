using System.ComponentModel.DataAnnotations;

namespace Mess_Management_System.Models
{
    public class MemberList
    {
        [Key]
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
    }
}
