using ToDoMonolithApi.Domain.Dtos;
using ToDoMonolithApi.Domain.Entities;

namespace ToDoMonolithApi.Domain.Mapping;

public static class UserMappings
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            UserName = user.UserName,
            Password = user.Password,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
            Tasks = user.Tasks?.Select(task => new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt,
                Status = task.Status,
                UserId = task.UserId
            }).ToList()
        };
    }

    public static UserToAddDto ToAddDto(this User user)
    {
        return new UserToAddDto
        {
            Name = user.Name,
            Email = user.Email,
            UserName = user.UserName,
            Password = user.Password
        };
    }

    public static UserToUpdateDto ToUpdateDto(this User user)
    {
        return new UserToUpdateDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            UserName = user.UserName,
            Password = user.Password
        };
    }

    public static User ToEntity(this UserDto userDto)
    {
        return new User
        {
            Id = userDto.Id,
            Name = userDto.Name,
            Email = userDto.Email,
            UserName = userDto.UserName,
            Password = userDto.Password,
            CreatedAt = userDto.CreatedAt,
            UpdatedAt = userDto.UpdatedAt,
            Tasks = userDto.Tasks.Select(taskDto => new Entities.Task
            {
                Id = taskDto.Id,
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                CreatedAt = taskDto.CreatedAt,
                UpdatedAt = taskDto.UpdatedAt,
                Status = taskDto.Status,
                UserId = taskDto.UserId
            }).ToList()
        };
    }

    public static User ToEntity(this UserToAddDto userToAddDto)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            Name = userToAddDto.Name,
            Email = userToAddDto.Email,
            UserName = userToAddDto.UserName,
            Password = userToAddDto.Password,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }
}
