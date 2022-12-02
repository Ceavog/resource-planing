namespace Backend.Shared.Exceptions.ProductExceptions;

public class ProductWithThisNameAlreadyExistsForThisUserException : Exception
{
    public string Login { get; }
    public string ProductName { get; }
    
    public ProductWithThisNameAlreadyExistsForThisUserException(string login, string productName) 
        : base($"Product with name {productName} already exists for user with login {login}")
    {
        Login = login;
        ProductName = productName;
    }
}