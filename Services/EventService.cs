using EventEaseApp.Models;

namespace EventEaseApp.Services;

public class EventService
{
    private readonly List<EventModel> _events = new()
    {
        new EventModel
        {
            Id = 1,
            Name = "Corporate Leadership Summit",
            Date = DateTime.Today.AddDays(14).AddHours(9),
            Location = "Houston Convention Center",
            Category = "Corporate",
            Description = "A professional development event focused on leadership, collaboration, and team growth.",
            Capacity = 250
        },
        new EventModel
        {
            Id = 2,
            Name = "Community Networking Night",
            Date = DateTime.Today.AddDays(21).AddHours(18),
            Location = "Bayfront Event Hall",
            Category = "Social",
            Description = "A relaxed evening for local professionals and community leaders to connect.",
            Capacity = 150
        },
        new EventModel
        {
            Id = 3,
            Name = "Digital Marketing Workshop",
            Date = DateTime.Today.AddDays(28).AddHours(13),
            Location = "Innovation Lab Room 204",
            Category = "Workshop",
            Description = "A hands-on workshop covering social media, email campaigns, analytics, and content strategy.",
            Capacity = 80
        },
        new EventModel
        {
            Id = 4,
            Name = "Annual Charity Gala",
            Date = DateTime.Today.AddDays(35).AddHours(19),
            Location = "Grand Oak Ballroom",
            Category = "Fundraiser",
            Description = "A formal fundraising event with dinner, guest speakers, and community recognition.",
            Capacity = 300
        },
        new EventModel
        {
            Id = 5,
            Name = "Small Business Expo",
            Date = DateTime.Today.AddDays(42).AddHours(10),
            Location = "Downtown Civic Center",
            Category = "Expo",
            Description = "A showcase for entrepreneurs, vendors, and business service providers.",
            Capacity = 500
        },
        new EventModel
        {
            Id = 6,
            Name = "Project Management Bootcamp",
            Date = DateTime.Today.AddDays(49).AddHours(8),
            Location = "Training Center A",
            Category = "Training",
            Description = "A full-day bootcamp covering planning, risk, stakeholders, schedules, and delivery.",
            Capacity = 60
        }
    };

    private readonly List<EventRegistration> _registrations = new();
    private int _nextRegistrationId = 1;

    public IReadOnlyList<EventModel> GetEvents()
    {
        return _events;
    }

    public EventModel? GetEventById(int id)
    {
        return _events.FirstOrDefault(e => e.Id == id);
    }

    public IEnumerable<EventModel> SearchEvents(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            return _events;
        }

        string query = searchText.Trim();

        return _events.Where(e =>
            e.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            e.Location.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            e.Category.Contains(query, StringComparison.OrdinalIgnoreCase));
    }

    public IReadOnlyList<EventRegistration> GetRegistrations()
    {
        return _registrations;
    }

    public IEnumerable<EventRegistration> GetRegistrationsForEvent(int eventId)
    {
        return _registrations.Where(r => r.EventId == eventId);
    }

    public bool Register(EventRegistration registration, out string message)
    {
        EventModel? eventItem = GetEventById(registration.EventId);

        if (eventItem is null)
        {
            message = "The selected event could not be found.";
            return false;
        }

        bool duplicateRegistration = _registrations.Any(r =>
            r.EventId == registration.EventId &&
            r.Email.Equals(registration.Email, StringComparison.OrdinalIgnoreCase));

        if (duplicateRegistration)
        {
            message = "This email is already registered for the selected event.";
            return false;
        }

        int currentCount = _registrations.Count(r => r.EventId == registration.EventId);
        if (currentCount >= eventItem.Capacity)
        {
            message = "This event has reached capacity.";
            return false;
        }

        registration.Id = _nextRegistrationId++;
        registration.EventName = eventItem.Name;
        registration.RegisteredAt = DateTime.Now;

        _registrations.Add(new EventRegistration
        {
            Id = registration.Id,
            EventId = registration.EventId,
            EventName = registration.EventName,
            Name = registration.Name,
            Email = registration.Email,
            Phone = registration.Phone,
            TicketType = registration.TicketType,
            RegisteredAt = registration.RegisteredAt,
            CheckedIn = false
        });

        message = "Registration completed successfully.";
        return true;
    }

    public bool CheckInRegistration(int registrationId)
    {
        EventRegistration? registration = _registrations.FirstOrDefault(r => r.Id == registrationId);

        if (registration is null)
        {
            return false;
        }

        registration.CheckedIn = true;
        return true;
    }
}
