using ToDoMonolithApi.Domain.Dtos;
using ToDoMonolithApi.Domain.Entities;
using ToDoMonolithApi.Domain.Mapping;

namespace ToDoMonolithApi.Core;

public class UserCore(ToDoMonolithContext context)
{
    private readonly ToDoMonolithContext _context = context;

    public IEnumerable<UserDto> GetUsers()
    {
        return _context.Users.Select(user => user.ToDto()).ToList();
    }

    public UserDto? GetUserByGuid(Guid id)
    {
        var user = _context.Users.Find(id);
        if (user == null) return null;
        return user.ToDto();
    }

    public bool AddUser(UserToAddDto userToAddDto)
    {
        var user = userToAddDto.ToEntity();
        _context.Users.Add(user);
        _context.SaveChanges();
        return true;
    }

    public bool UpdateUser(UserToUpdateDto userToUpdateDto)
    {
        var user = _context.Users.Find(userToUpdateDto.Id);
        if (user == null) return false;

        user.Name = userToUpdateDto.Name;
        user.Email = userToUpdateDto.Email;
        user.UserName = userToUpdateDto.UserName;
        user.Password = userToUpdateDto.Password;
        user.UpdatedAt = DateTime.Now;

        _context.Users.Update(user);
        _context.SaveChanges();
        return true;
    }

    public bool DeleteUser(Guid id)
    {
        var user = _context.Users.Find(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        _context.SaveChanges();
        return true;
    }
}
