using TheGadgetHubAPI.Models;

public static class NotificationStore
{
    private static readonly Dictionary<Guid, OrderNotification> _notifications = new();

    public static Guid AddNotification(OrderNotification notification)
    {
        var id = Guid.NewGuid();
        _notifications[id] = notification;
        return id;
    }

    public static OrderNotification? GetNotification(Guid id)
    {
        _notifications.TryGetValue(id, out var notification);
        return notification;
    }

    public static void RemoveNotification(Guid id)
    {
        if (_notifications.ContainsKey(id))
        {
            _notifications.Remove(id);
        }
    }
}
