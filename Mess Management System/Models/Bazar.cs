namespace Mess_Management_System.Models
{
    public class Bazar
    {
        public int bazarId { get; set; }
        public int MemberId { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
