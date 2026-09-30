using EventEaseApp.Models;

namespace EventEaseApp.Services;

public class UserSessionService
{
    public string? CurrentUserName { get; private set; }
    public string? CurrentUserEmail { get; private set; }
    public string? LastViewedEventName { get; private set; }
    public int? LastViewedEventId { get; private set; }
    public int RegistrationCount { get; private set; }

    public event Action? OnChange;

    public void TrackEventView(EventModel eventItem)
    {
        LastViewedEventId = eventItem.Id;
        LastViewedEventName = eventItem.Name;
        NotifyStateChanged();
    }

    public void TrackRegistration(EventRegistration registration)
    {
        CurrentUserName = registration.Name;
        CurrentUserEmail = registration.Email;
        RegistrationCount++;
        NotifyStateChanged();
    }

    public void ClearSession()
    {
        CurrentUserName = null;
        CurrentUserEmail = null;
        LastViewedEventName = null;
        LastViewedEventId = null;
        RegistrationCount = 0;
        NotifyStateChanged();
    }

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}
