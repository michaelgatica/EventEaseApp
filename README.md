# EventEaseApp

EventEase is a Blazor WebAssembly event management app created for the three-part Microsoft Copilot practice project.

## Features

- Reusable Event Card component
- Event name, date, location, category, description, and capacity fields
- Two-way data binding in the Event Card preview editor
- Event list with search and optimized rendering using `Virtualize`
- Routing between home, event list, details, registration, attendance, and session tracker pages
- Graceful handling for invalid event routes
- Registration form with data validation
- State management through `UserSessionService`
- Attendance tracker with check-in functionality
- Clean CSS and responsive layout

## Run the project

```bash
cd EventEaseApp
dotnet restore
dotnet run
```

Open the local URL shown in the terminal.

## Suggested testing

1. Go to `/events`.
2. Search for an event.
3. Use **Edit Preview** on an event card to test two-way binding.
4. View event details.
5. Register for an event.
6. Confirm validation catches missing or invalid fields.
7. View the attendance tracker.
8. Check in a registered attendee.
9. Visit the session tracker.
10. Try an invalid route such as `/event/999` to confirm graceful error handling.

## Main files

- `Components/EventCard.razor`
- `Pages/Events.razor`
- `Pages/EventDetails.razor`
- `Pages/Register.razor`
- `Pages/Attendance.razor`
- `Pages/SessionTracker.razor`
- `Services/EventService.cs`
- `Services/UserSessionService.cs`
- `Models/EventModel.cs`
- `Models/EventRegistration.cs`
