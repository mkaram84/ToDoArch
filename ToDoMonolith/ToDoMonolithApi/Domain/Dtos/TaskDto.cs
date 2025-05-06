namespace ToDoMonolithApi.Domain.Dtos;

public record TaskDto(Guid Id,
                      string Title,
                      string Description,
                      DateTime DueDate,
                      DateTime CreatedAt,
                      DateTime UpdatedAt,
                      TaskStatus Status,
                      Guid UserId,
                      UserDto User)
{
    public TaskDto() : this(default, default, default, default, default, default, default, default, default) { }
}

public record TaskToAddDto(string Title,
                           string Description,
                           DateTime DueDate,
                           TaskStatus Status,
                           Guid UserId)
{ 
    public TaskToAddDto() : this(default, default, default, default, default) { }
}
public record TaskToUpdateDto(Guid Id,
                              string Title,
                              string Description,
                              DateTime DueDate,
                              TaskStatus Status)
{ 
    public TaskToUpdateDto() : this(default, default, default, default, default) { }
}