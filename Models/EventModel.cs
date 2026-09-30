using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models;

public class EventModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Event name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Event date is required.")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Location is required.")]
    public string Location { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Range(1, 10000, ErrorMessage = "Capacity must be at least 1.")]
    public int Capacity { get; set; }
}
