using ReadOfStream.Models;

namespace ReadOfStream.Interface;

public interface IUserService
{
    User GetUserById(Guid userId);
    IEnumerable<User> GetUsersByDomain(string domain, int page, int pageSize);
    IEnumerable<User> GetUsersByTagAndDomain(string tagValue, string domain);
}