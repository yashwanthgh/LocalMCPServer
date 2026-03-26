using MCP.External.Data;
using MCP.External.Entities;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace MCP.External.Accessors
{
    [McpServerToolType]
    public class ExternalEventsAccessor
    {
        #region Private Methods

        private async Task<List<LytxEvent>> GetEvents()
        {
            using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(EventsStaticResource.EventsJson));
            var jsonDoc = await JsonDocument.ParseAsync(stream);
            var eventsElement = jsonDoc.RootElement.GetProperty("events");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var events = JsonSerializer.Deserialize<List<LytxEvent>>(eventsElement.GetRawText(), options);
            return events ?? new List<LytxEvent>();
        }

        private async Task<string> GetEventsAsString(List<LytxEvent>? events)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var eventsToSerialize = events ?? new List<LytxEvent>();
            using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, eventsToSerialize, options);
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }

        #endregion

        #region Public Methods

        [McpServerTool, Description("Get all Lytx events")]
        public async Task<string> GetAllEvents()
        {
            return await GetEventsAsString(await GetEvents());
        }

        [McpServerTool, Description("Get Lytx events by driver name")]
        public async Task<string> GetEventsByDriver(string driver)
        {
            var events = await GetEvents();
            var filteredEvents = events.Where(e => e.Driver != null && e.Driver.Equals(driver, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetEventsAsString(filteredEvents);
        }

        [McpServerTool, Description("Get Lytx events by status (e.g. FYI Notify, Face-To-Face, Resolved)")]
        public async Task<string> GetEventsByStatus(string status)
        {
            var events = await GetEvents();
            var filteredEvents = events.Where(e => e.Status != null && e.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetEventsAsString(filteredEvents);
        }

        [McpServerTool, Description("Get Lytx events by behavior (e.g. Smoking, Backing, Following Distance)")]
        public async Task<string> GetEventsByBehavior(string behavior)
        {
            var events = await GetEvents();
            var filteredEvents = events.Where(e => e.Behaviors != null && e.Behaviors.Contains(behavior, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetEventsAsString(filteredEvents);
        }

        [McpServerTool, Description("Get a Lytx event by its Event ID")]
        public async Task<string> GetEventByEventId(string eventId)
        {
            var events = await GetEvents();
            var filteredEvents = events.Where(e => e.EventId != null && e.EventId.Equals(eventId, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetEventsAsString(filteredEvents);
        }

        [McpServerTool, Description("Get Lytx events by employee ID")]
        public async Task<string> GetEventsByEmployeeId(string employeeId)
        {
            var events = await GetEvents();
            var filteredEvents = events.Where(e => e.EmployeeId != null && e.EmployeeId.Equals(employeeId, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetEventsAsString(filteredEvents);
        }

        [McpServerTool, Description("Get Lytx events by group (full or partial match, e.g. BCC - Smiths Station)")]
        public async Task<string> GetEventsByGroup(string group)
        {
            var events = await GetEvents();
            var filteredEvents = events.Where(e => e.Group != null && e.Group.Contains(group, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetEventsAsString(filteredEvents);
        }

        [McpServerTool, Description("Get Lytx events by vehicle ID")]
        public async Task<string> GetEventsByVehicle(string vehicle)
        {
            var events = await GetEvents();
            var filteredEvents = events.Where(e => e.Vehicle != null && e.Vehicle.Equals(vehicle, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetEventsAsString(filteredEvents);
        }

        [McpServerTool, Description("Get Lytx events by device ID")]
        public async Task<string> GetEventsByDevice(string device)
        {
            var events = await GetEvents();
            var filteredEvents = events.Where(e => e.Device != null && e.Device.Equals(device, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetEventsAsString(filteredEvents);
        }

        [McpServerTool, Description("Get Lytx events by date (format M/d/yy, e.g. 3/20/26)")]
        public async Task<string> GetEventsByDate(string date)
        {
            var events = await GetEvents();
            var filteredEvents = events.Where(e => e.Date != null && e.Date.Equals(date, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetEventsAsString(filteredEvents);
        }

        [McpServerTool, Description("Get Lytx events by trigger type (e.g. Braking, Cornering, Accelerating)")]
        public async Task<string> GetEventsByTrigger(string trigger)
        {
            var events = await GetEvents();
            var filteredEvents = events.Where(e => e.Trigger != null && e.Trigger.Contains(trigger, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetEventsAsString(filteredEvents);
        }

        [McpServerTool, Description("Get Lytx events by exact score value (e.g. 0, 2, 6, 8)")]
        public async Task<string> GetEventsByScore(string score)
        {
            var events = await GetEvents();
            var filteredEvents = events.Where(e => e.Score != null && e.Score.Equals(score, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetEventsAsString(filteredEvents);
        }

        [McpServerTool, Description("Get Lytx events with a score greater than or equal to the given minimum score")]
        public async Task<string> GetEventsByMinScore(int minScore)
        {
            var events = await GetEvents();
            var filteredEvents = events.Where(e => int.TryParse(e.Score, out var score) && score >= minScore).ToList();
            return await GetEventsAsString(filteredEvents);
        }

        [McpServerTool, Description("Get Lytx events that have no behaviors recorded")]
        public async Task<string> GetEventsWithNoBehaviors()
        {
            var events = await GetEvents();
            var filteredEvents = events.Where(e => string.IsNullOrWhiteSpace(e.Behaviors)).ToList();
            return await GetEventsAsString(filteredEvents);
        }

        [McpServerTool, Description("Get Lytx events that have one or more behaviors recorded")]
        public async Task<string> GetEventsWithBehaviors()
        {
            var events = await GetEvents();
            var filteredEvents = events.Where(e => !string.IsNullOrWhiteSpace(e.Behaviors)).ToList();
            return await GetEventsAsString(filteredEvents);
        }

        #endregion
    }
}
