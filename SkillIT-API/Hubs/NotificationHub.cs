using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace SkillIT_API.Hubs
{
    /// <summary>
    /// SignalR hub for real-time notifications and updates
    /// </summary>
    [Authorize]
    public class NotificationHub : Hub
    {
        private readonly ILogger<NotificationHub> _logger;

        public NotificationHub(ILogger<NotificationHub> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Called when a client connects to the hub
        /// </summary>
        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            _logger.LogInformation("Client connected: {ConnectionId}, User: {UserId}", 
                Context.ConnectionId, userId);

            // Add to user's personal group
            if (!string.IsNullOrEmpty(userId))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, $"user_{userId}");
            }

            await base.OnConnectedAsync();
        }

        /// <summary>
        /// Called when a client disconnects from the hub
        /// </summary>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = Context.UserIdentifier;
            _logger.LogInformation("Client disconnected: {ConnectionId}, User: {UserId}, Exception: {Exception}", 
                Context.ConnectionId, userId, exception?.Message);

            await base.OnDisconnectedAsync(exception);
        }

        /// <summary>
        /// Join a specific group (e.g., course group)
        /// </summary>
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            _logger.LogInformation("Client {ConnectionId} joined group {GroupName}", 
                Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("UserJoined", Context.ConnectionId);
        }

        /// <summary>
        /// Leave a specific group
        /// </summary>
        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            _logger.LogInformation("Client {ConnectionId} left group {GroupName}", 
                Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("UserLeft", Context.ConnectionId);
        }

        /// <summary>
        /// Send a notification to a specific user
        /// </summary>
        public async Task SendNotificationToUser(string userId, string message, string type = "info")
        {
            _logger.LogInformation("Sending notification to user {UserId}: {Message}", userId, message);

            await Clients.Group($"user_{userId}").SendAsync("ReceiveNotification", new
            {
                Message = message,
                Type = type,
                Timestamp = DateTime.UtcNow
            });
        }

        /// <summary>
        /// Broadcast notification to all connected clients
        /// </summary>
        public async Task BroadcastNotification(string message, string type = "info")
        {
            _logger.LogInformation("Broadcasting notification: {Message}", message);

            await Clients.All.SendAsync("ReceiveNotification", new
            {
                Message = message,
                Type = type,
                Timestamp = DateTime.UtcNow
            });
        }

        /// <summary>
        /// Send course update notification to all users enrolled in a course
        /// </summary>
        public async Task SendCourseUpdate(int courseId, string message)
        {
            var groupName = $"course_{courseId}";
            _logger.LogInformation("Sending course update to {GroupName}: {Message}", groupName, message);

            await Clients.Group(groupName).SendAsync("CourseUpdated", new
            {
                CourseId = courseId,
                Message = message,
                Timestamp = DateTime.UtcNow
            });
        }
    }
}
