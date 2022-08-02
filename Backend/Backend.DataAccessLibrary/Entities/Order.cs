namespace Backend.DataAccessLibrary;

public class Order
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime MyProperty { get; set; }
    public int OrderTypeId { get; set; }
}