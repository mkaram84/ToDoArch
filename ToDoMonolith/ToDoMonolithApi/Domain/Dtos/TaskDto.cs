namespace ToDoMonolithApi.Domain.Dtos;

public record TaskDto(Guid Id,
                      string Title,
                      string Description,
                      DateTime DueDate,
                      DateTime CreatedAt,
                      DateTime UpdatedAt,
                      TaskStatus Status,
                      UserDto User);
public record TaskToAddDto(string Title,
                           string Description,
                           DateTime DueDate,
                           TaskStatus Status,
                           Guid UserId);
public record TaskToUpdateDto(Guid Id,
                              string Title,
                              string Description,
                              DateTime DueDate,
                              TaskStatus Status);