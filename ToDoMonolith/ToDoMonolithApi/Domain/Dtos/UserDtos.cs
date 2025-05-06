namespace ToDoMonolithApi.Domain.Dtos;

public record UserDto(Guid Id,
                      string Name,
                      string Email,
                      string UserName,
                      string Password,
                      DateTime CreatedAt,
                      DateTime UpdatedAt,
                      IEnumerable<TaskDto> Tasks)
{
    public UserDto() : this(default, default, default, default, default, default, default, default) {}
}

public record UserToAddDto(string Name,
                           string Email,
                           string UserName,
                           string Password)
{
    public UserToAddDto() : this(default, default, default, default) {}
}

public record UserToUpdateDto(Guid Id,
                              string Name,
                              string Email,
                              string UserName,
                              string Password)
{
    public UserToUpdateDto() : this(default, default, default, default, default) {}
}
