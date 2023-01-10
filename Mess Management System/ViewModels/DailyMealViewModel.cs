using Mess_Management_System.Common_Daterange_Attribute;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Mess_Management_System.ViewModels
{
    public class DailyMealViewModel
    {
        [Display(Name = "Meal Id")]
        public int MealId { get; set; }
        [Display(Name = "Member Id")]
        public int MemberId { get; set; }
        [Display(Name = "Member Name")]
        public string? MemberName { get; set; }
        [Range(0,10,ErrorMessage ="value not less than 0 or grater than 10")]
        //[Range(0,int.MaxValue,ErrorMessage = "value not less than 0")]
        public int Breakfast { get; set; }
        [Range(0, 10, ErrorMessage = "value not less than 0 or grater than 10")]
        public int Lunch { get; set; }
        [Range(0, 10, ErrorMessage = "value not less than 0 or grater than 10")]
        public int Dinner { get; set; }
        //[CurrentDate]
        public DateTime Date { get; set; }
        public string? Email { get; set; }
    }
}
