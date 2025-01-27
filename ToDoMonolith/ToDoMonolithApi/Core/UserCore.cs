using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoMonolithApi.Domain.Dtos;
using ToDoMonolithApi.Domain.Entities;

namespace ToDoMonolithApi.Core;

public class UserCore(ToDoMonolithContext context, IMapper mapper)
{
    private readonly ToDoMonolithContext _context = context;
    private readonly IMapper _mapper = mapper;

    public IEnumerable<UserDto> GetUsers()
    {
        return _mapper.Map<IEnumerable<UserDto>>(_context.Users.ToList());
    }

    public UserDto? GetUserByGuid(Guid id)
    {
        return _mapper.Map<UserDto?>(_context.Users.Find(id));
    }

    public bool AddUser(UserToAddDto userToAddDto)
    {
        var user = _mapper.Map<User>(userToAddDto);
        user.Id = Guid.NewGuid();
        user.CreatedAt = DateTime.Now;
        user.UpdatedAt = DateTime.Now;
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
