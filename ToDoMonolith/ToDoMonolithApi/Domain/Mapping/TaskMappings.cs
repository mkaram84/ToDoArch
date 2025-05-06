using ToDoMonolithApi.Domain.Dtos;

namespace ToDoMonolithApi.Domain.Mapping;

public static class TaskMappings
{
    public static TaskDto ToDto(this Entities.Task task)
    {
        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            CreatedAt = task.CreatedAt,
            UpdatedAt = task.UpdatedAt,
            Status = task.Status,
            UserId = task.UserId
        };
    }
    public static TaskToAddDto ToAddDto(this Entities.Task task)
    {
        return new TaskToAddDto
        {
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            Status = task.Status,
            UserId = task.UserId
        };
    }
    public static TaskToUpdateDto ToUpdateDto(this Entities.Task task)
    {
        return new TaskToUpdateDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            Status = task.Status
        };
    }

    public static Entities.Task ToEntity(this TaskDto taskDto)
    {
        return new Entities.Task
        {
            Id = taskDto.Id,
            Title = taskDto.Title,
            Description = taskDto.Description,
            DueDate = taskDto.DueDate,
            Status = taskDto.Status,
            UserId = taskDto.UserId
        };
    }

    public static Entities.Task ToEntity(this TaskToAddDto taskToAddDto)
    {
        return new Entities.Task
        {
            Title = taskToAddDto.Title,
            Description = taskToAddDto.Description,
            DueDate = taskToAddDto.DueDate,
            Status = taskToAddDto.Status,
            UserId = taskToAddDto.UserId,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }
}
