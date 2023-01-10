
using System.ComponentModel.DataAnnotations;

namespace Mess_Management_System.Models
{
    public class DailyMeal
    {
        [Key]
        public int MealId { get; set; }
        public int MemberId { get; set; }
        public int Breakfast { get; set; }
        public int Lunch { get; set; }
        public int Dinner { get; set; }
        public DateTime Date { get; set; }
    }
}