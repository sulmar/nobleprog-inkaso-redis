namespace _01_RedisStrings.Domain;

public interface ICustomerRepository
{
    Task<Customer?> GetAsync(int id);
}
