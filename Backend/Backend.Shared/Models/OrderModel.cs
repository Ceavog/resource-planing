namespace Shared.Models;

public class OrderModel
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime DateTime { get; set; }
    public int OrderTypeId { get; set; }
    public bool IsFinished { get; set; }
    
}