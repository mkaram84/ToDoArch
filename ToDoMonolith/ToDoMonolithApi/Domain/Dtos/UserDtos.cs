namespace ToDoMonolithApi.Domain.Dtos;

public record UserDto(Guid Id,
                      string Name,
                      string Email,
                      string UserName,
                      string Password,
                      DateTime CreatedAt,
                      DateTime UpdatedAt,
                      IEnumerable<Entities.Task> Tasks);
public record UserToAddDto(string Name,
                           string Email,
                           string UserName,
                           string Password);
public record UserToUpdateDto(Guid Id,
                              string Name,
                              string Email,
                              string UserName,
                              string Password);
