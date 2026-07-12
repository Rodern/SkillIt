# SignalR Real-Time Features Guide

This guide explains how to use the SignalR real-time notification system in SkillIT.

## Overview

SignalR enables real-time bidirectional communication between the server and clients. SkillIT uses SignalR for:
- Real-time notifications
- Course updates
- User activity tracking
- Live engagement features

## Hub Endpoint

**URL:** `/hubs/notifications`

## Client Implementation

### JavaScript/TypeScript

```javascript
// Install SignalR client
// npm install @microsoft/signalr

import * as signalR from "@microsoft/signalr";

// Create connection
const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://your-api-url/hubs/notifications", {
        accessTokenFactory: () => "your-jwt-token"
    })
    .withAutomaticReconnect()
    .build();

// Handle connection events
connection.on("ReceiveNotification", (data) => {
    console.log("Notification received:", data);
    // data: { Message, Type, Timestamp }
    showNotification(data.Message, data.Type);
});

connection.on("CourseUpdated", (data) => {
    console.log("Course updated:", data);
    // data: { CourseId, Message, Timestamp }
    refreshCourseData(data.CourseId);
});

// Start connection
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected");
        
        // Join course group (e.g., when viewing a course)
        await connection.invoke("JoinGroup", "course_123");
    } catch (err) {
        console.error("SignalR Connection Error:", err);
        setTimeout(start, 5000);
    }
}

connection.onclose(async () => {
    await start();
});

start();
```

### Blazor (C#)

```csharp
@page "/dashboard"
@using Microsoft.AspNetCore.SignalR.Client
@inject NavigationManager Navigation
@implements IAsyncDisposable

<h3>Dashboard</h3>
<p>Notifications: @notificationCount</p>

@code {
    private HubConnection hubConnection;
    private int notificationCount = 0;

    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl(Navigation.ToAbsoluteUri("/hubs/notifications"), options =>
            {
                options.AccessTokenProvider = async () => await GetJwtToken();
            })
            .WithAutomaticReconnect()
            .Build();

        hubConnection.On<object>("ReceiveNotification", (notification) =>
        {
            notificationCount++;
            InvokeAsync(StateHasChanged);
        });

        hubConnection.On<object>("CourseUpdated", (update) =>
        {
            // Handle course update
            InvokeAsync(StateHasChanged);
        });

        await hubConnection.StartAsync();
    }

    private async Task<string> GetJwtToken()
    {
        // Return your JWT token
        return await Task.FromResult("your-jwt-token");
    }

    public async ValueTask DisposeAsync()
    {
        if (hubConnection is not null)
        {
            await hubConnection.DisposeAsync();
        }
    }
}
```

## Server Methods

### JoinGroup

Join a specific group to receive targeted notifications.

```javascript
await connection.invoke("JoinGroup", "course_123");
```

**Parameters:**
- `groupName`: Name of the group (e.g., "course_123")

### LeaveGroup

Leave a group to stop receiving its notifications.

```javascript
await connection.invoke("LeaveGroup", "course_123");
```

### SendNotificationToUser

Send a notification to a specific user (admin/instructor only).

```javascript
await connection.invoke("SendNotificationToUser", "userId", "Your assignment was graded", "success");
```

**Parameters:**
- `userId`: Target user ID
- `message`: Notification message
- `type`: Notification type ("info", "success", "warning", "error")

### BroadcastNotification

Send a notification to all connected users (admin only).

```javascript
await connection.invoke("BroadcastNotification", "System maintenance in 10 minutes", "warning");
```

### SendCourseUpdate

Notify all users in a course group.

```javascript
await connection.invoke("SendCourseUpdate", 123, "New lesson added to Chapter 3");
```

**Parameters:**
- `courseId`: Course ID
- `message`: Update message

## Client Events

### ReceiveNotification

Triggered when receiving any notification.

```javascript
connection.on("ReceiveNotification", (data) => {
    // data: { Message, Type, Timestamp }
});
```

### CourseUpdated

Triggered when a course is updated.

```javascript
connection.on("CourseUpdated", (data) => {
    // data: { CourseId, Message, Timestamp }
});
```

### UserJoined / UserLeft

Triggered when users join or leave a group.

```javascript
connection.on("UserJoined", (connectionId) => {
    console.log("User joined:", connectionId);
});

connection.on("UserLeft", (connectionId) => {
    console.log("User left:", connectionId);
});
```

## Use Cases

### 1. Real-Time Course Notifications

```javascript
// When viewing a course
async function viewCourse(courseId) {
    // Join the course group
    await connection.invoke("JoinGroup", `course_${courseId}`);
    
    // Listen for updates
    connection.on("CourseUpdated", (data) => {
        if (data.CourseId === courseId) {
            showToast(data.Message);
            reloadCourseContent();
        }
    });
}
```

### 2. Achievement Notifications

```javascript
connection.on("ReceiveNotification", (data) => {
    if (data.Type === "achievement") {
        showAchievementPopup(data.Message);
        playSound("achievement.mp3");
    }
});
```

### 3. Live Quiz Updates

```javascript
// Join quiz session
await connection.invoke("JoinGroup", `quiz_${quizId}`);

// Handle real-time updates
connection.on("QuizUpdated", (data) => {
    updateQuizState(data);
});
```

### 4. Instructor Broadcasting to Students

```javascript
// Instructor sends announcement to course
async function announceToStudents(courseId, message) {
    await connection.invoke("SendCourseUpdate", courseId, message);
}
```

## Authentication

SignalR connections are authenticated using JWT tokens. Include your token when establishing the connection:

```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/notifications", {
        accessTokenFactory: () => localStorage.getItem("jwtToken")
    })
    .build();
```

## Error Handling

```javascript
connection.onclose((error) => {
    console.error("Connection closed:", error);
    // Attempt reconnection
    setTimeout(() => start(), 5000);
});

connection.onreconnecting((error) => {
    console.warn("Connection lost, reconnecting...", error);
    showReconnectingMessage();
});

connection.onreconnected((connectionId) => {
    console.log("Reconnected:", connectionId);
    hideReconnectingMessage();
    // Rejoin groups if needed
});
```

## Best Practices

1. **Always handle disconnections** - Implement automatic reconnection logic
2. **Clean up on unmount** - Dispose connections when components unmount
3. **Use groups wisely** - Join only groups you need, leave when done
4. **Validate messages** - Always validate incoming data on the client
5. **Rate limiting** - Be mindful of message frequency
6. **Security** - Never trust client data, validate on server

## Testing

Test SignalR locally:

```bash
# Start the API
cd SkillIT-API
dotnet run

# In browser console
const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7000/hubs/notifications")
    .build();

await connection.start();
console.log("Connected!");
```

## Troubleshooting

### Connection Fails

- Verify JWT token is valid and not expired
- Check CORS settings allow SignalR connections
- Ensure `AllowCredentials()` is enabled in CORS policy

### Messages Not Received

- Verify you're joined to the correct group
- Check server logs for errors
- Ensure event handler is registered before messages are sent

### Reconnection Issues

- Implement `.withAutomaticReconnect()` when building connection
- Handle `onreconnected` to rejoin groups after reconnection

## Additional Resources

- [SignalR Documentation](https://docs.microsoft.com/en-us/aspnet/core/signalr/introduction)
- [JavaScript Client](https://docs.microsoft.com/en-us/aspnet/core/signalr/javascript-client)
- [.NET Client](https://docs.microsoft.com/en-us/aspnet/core/signalr/dotnet-client)
