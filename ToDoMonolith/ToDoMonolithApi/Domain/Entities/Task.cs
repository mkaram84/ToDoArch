﻿namespace ToDoMonolithApi.Domain.Entities;

public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public TaskStatus Status { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}
