using ReadOfStream.DbContexts;
using ReadOfStream.Interface;
using ReadOfStream.Models;

namespace ReadOfStream.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _dbContext;

    public UserService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User GetUserById(Guid userId)
    {
        return _dbContext.Users.FirstOrDefault(u => u.UserId == userId);
    }

    public IEnumerable<User> GetUsersByDomain(string domain, int page, int pageSize)
    {
        return _dbContext.Users
            .Where(u => u.Domain == domain)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public IEnumerable<User> GetUsersByTagAndDomain(string tagValue, string domain)
    {
        var query = from u in _dbContext.Users
                    join tu in _dbContext.TagToUsers on u.UserId equals tu.UserId
                    join t in _dbContext.Tags on tu.TagId equals t.TagId
                    where u.Domain == domain && t.Value == tagValue
                    select u;

        return query.ToList();
    }
}
