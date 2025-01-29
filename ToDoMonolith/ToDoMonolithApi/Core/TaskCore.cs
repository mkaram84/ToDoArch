using AutoMapper;
using ToDoMonolithApi.Domain.Dtos;

namespace ToDoMonolithApi.Core;

public class TaskCore(ToDoMonolithContext context, IMapper mapper)
{
    private readonly ToDoMonolithContext _context = context;
    private readonly IMapper _mapper = mapper;

    public IEnumerable<TaskDto> GetTasksByUserId(Guid userId)
    {
        return _mapper.Map<IEnumerable<TaskDto>>(_context.Tasks.Select(q => q.UserId == userId).ToList());
    }

    public TaskDto GetTaskById(Guid taskId)
    {
        return _mapper.Map<TaskDto>(_context.Tasks.Find(taskId));
    }

    public bool AddTask(TaskToAddDto taskToAddDto)
    {
        var task = _mapper.Map<Domain.Entities.Task>(taskToAddDto);
        task.Id = Guid.NewGuid();
        task.CreatedAt = DateTime.Now;
        task.UpdatedAt = DateTime.Now;
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
