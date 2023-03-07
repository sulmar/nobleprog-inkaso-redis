using _01_RedisStrings.Domain;
using StackExchange.Redis;
using System.Text.Json;

namespace _01_RedisStrings.Infrastructure;

public class CachedCustomerRepository : ICustomerRepository
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IConnectionMultiplexer _muxer;

    private readonly TimeSpan DefaultExpiration = TimeSpan.FromMinutes(1);

    public CachedCustomerRepository(ICustomerRepository customerRepository, IConnectionMultiplexer muxer)
    {
        _customerRepository = customerRepository;
        _muxer = muxer;
    }

    #region Oryginalna metoda
    //public async Task<Customer?> GetAsync(int id)
    //{
    //    var key = $"customer:{id}";

    //    var db = _muxer.GetDatabase();

    //    // GET key
    //    var value = db.StringGet(key);

    //    if (!value.IsNull)
    //    {
    //        var customer = JsonSerializer.Deserialize<Customer>(value);

    //        return customer;
    //    }
    //    else
    //    {
    //        var customer = await _customerRepository.GetAsync(id);

    //        if (customer == null) return null;

    //        value = JsonSerializer.Serialize(customer);

    //        // SET key value EX seconds
    //        db.StringSet(key, value, expiry: DefaultExpiration);

    //        return customer;
    //    }
    //}
    #endregion

    // Refactored - zastosowanie metody generycznej
    public Task<Customer?> GetAsync(int id) => GetOrAdd(id, () => _customerRepository.GetAsync(id));

    
    private async Task<TValue> GetOrAdd<TKey, TValue>(TKey id, Func<Task<TValue>> func)
    {
        var key = $"{typeof(TValue).Name.ToLower()}:{id}";

        var db = _muxer.GetDatabase();
        var value = db.StringGet(key); 
        
        if (!value.IsNull) 
        {
            var item = JsonSerializer.Deserialize<TValue>(value);
            return item;
        }
        else
        {
            var item = await func();
            value = JsonSerializer.Serialize(item);
            await db.StringSetAsync(key, value, expiry: DefaultExpiration);
            return item;

        }
    }
}
