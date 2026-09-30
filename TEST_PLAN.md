# EventEase Test Plan

## Event Card and Data Binding

- Open `/events`.
- Click **Edit Preview** on an event card.
- Change the event name, date, or location.
- Click **Apply Preview**.
- Confirm the card updates immediately.
- Try leaving the event name blank and confirm validation prevents the update.

## Routing

- Navigate to `/events`.
- Click **View Details** on an event.
- Confirm `/event/{id}` displays the correct event.
- Navigate to `/event/999`.
- Confirm the app shows an Event Not Found message instead of crashing.

## Registration Validation

- Navigate to a registration page.
- Submit the form with empty fields.
- Confirm validation messages appear.
- Enter an invalid email address.
- Confirm email validation works.
- Submit valid data and confirm the registration saves.

## Attendance Tracker

- Register for an event.
- Open `/attendance`.
- Confirm the registration appears.
- Click **Check In**.
- Confirm the attendee status updates to Checked In.

## Session Tracker

- View an event.
- Register for an event.
- Open `/session`.
- Confirm the latest user, email, last viewed event, and registration count are displayed.
- Click **Clear Session** and confirm the session resets.

## Performance

- Open `/events`.
- Confirm event cards render correctly.
- Search/filter the event list.
- Confirm the list updates without errors.
- Verify that `Virtualize` is used in `Events.razor` for optimized rendering.
