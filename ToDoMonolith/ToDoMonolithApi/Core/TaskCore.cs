using ToDoMonolithApi.Domain.Dtos;
using ToDoMonolithApi.Domain.Mapping;

namespace ToDoMonolithApi.Core;

public class TaskCore(ToDoMonolithContext context)
{
    private readonly ToDoMonolithContext _context = context;

    public IEnumerable<TaskDto> GetTasksByUserId(Guid userId)
    {
        return _context.Tasks
            .Where(q => q.UserId == userId)
            .Select(task => task.ToDto())
            .ToList();
    }

    public TaskDto? GetTaskById(Guid taskId)
    {
        var task = _context.Tasks.Find(taskId);
        if (task == null) return null;
        return task.ToDto();
    }

    public bool AddTask(TaskToAddDto taskToAddDto)
    {
        var task = taskToAddDto.ToEntity();
        _context.Tasks.Add(task);
        _context.SaveChanges();
        return true;
    }

    public bool UpdateTask(TaskToUpdateDto taskToUpdateDto)
    {
        var task = _context.Tasks.Find(taskToUpdateDto.Id);
        if (task == null) return false;

        task.Title = taskToUpdateDto.Title;
        task.Description = taskToUpdateDto.Description;
        task.DueDate = taskToUpdateDto.DueDate;
        task.Status = taskToUpdateDto.Status;
        task.UpdatedAt = DateTime.Now;

        _context.Tasks.Update(task);
        _context.SaveChanges();
        return true;
    }

    public bool DeleteTask(Guid taskId)
    {
        var task = _context.Tasks.Find(taskId);
        if (task == null) return false;

        _context.Tasks.Remove(task);
        _context.SaveChanges();
        return true;
    }
}
