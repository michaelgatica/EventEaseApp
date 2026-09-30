using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models;

public class EventRegistration
{
    public int Id { get; set; }

    public int EventId { get; set; }

    public string EventName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(80, ErrorMessage = "Name cannot exceed 80 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please choose a ticket type.")]
    public string TicketType { get; set; } = "General Admission";

    public DateTime RegisteredAt { get; set; } = DateTime.Now;

    public bool CheckedIn { get; set; }
}
