using System.ComponentModel.DataAnnotations;

namespace LeaveService.Models
{
    public class LeaveRequest
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; } = "Annual";
        public string Status { get; set; } = "Pending";
    }
}
