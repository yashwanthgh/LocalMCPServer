using MCP.External.Data;
using MCP.External.Entities;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace MCP.External.Accessors
{
    [McpServerToolType]
    public class UsersAccessor
    {
        #region Private Methods

        private async Task<List<LytxUser>> GetUsers()
        {
            using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(UsersStaticResource.UsersJson));
            var jsonDoc = await JsonDocument.ParseAsync(stream);
            var usersElement = jsonDoc.RootElement.GetProperty("users").GetProperty("value");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var users = JsonSerializer.Deserialize<List<LytxUser>>(usersElement.GetRawText(), options);
            return users ?? new List<LytxUser>();
        }

        private async Task<string> GetUsersAsString(List<LytxUser>? users)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var usersToSerialize = users ?? new List<LytxUser>();
            using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, usersToSerialize, options);
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }

        #endregion

        #region Public Methods

        [McpServerTool, Description("Get all users")]
        public async Task<string> GetAllUsers()
        {
            return await GetUsersAsString(await GetUsers());
        }

        [McpServerTool, Description("Get users by status (e.g. Active)")]
        public async Task<string> GetUsersByStatus(string status)
        {
            var users = await GetUsers();
            var filteredUsers = users.Where(u => u.Status != null && u.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetUsersAsString(filteredUsers);
        }

        [McpServerTool, Description("Get users by login state (Enabled or Disabled)")]
        public async Task<string> GetUsersByLoginState(string loginState)
        {
            var users = await GetUsers();
            var filteredUsers = users.Where(u => u.Login != null && u.Login.Equals(loginState, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetUsersAsString(filteredUsers);
        }

        [McpServerTool, Description("Get users by name (full or partial match)")]
        public async Task<string> GetUsersByName(string name)
        {
            var users = await GetUsers();
            var filteredUsers = users.Where(u => u.Name != null && u.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetUsersAsString(filteredUsers);
        }

        [McpServerTool, Description("Get users by employee ID")]
        public async Task<string> GetUsersByEmployeeId(string employeeId)
        {
            var users = await GetUsers();
            var filteredUsers = users.Where(u => u.EmployeeId != null && u.EmployeeId.Equals(employeeId, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetUsersAsString(filteredUsers);
        }

        [McpServerTool, Description("Get users by username")]
        public async Task<string> GetUsersByUsername(string username)
        {
            var users = await GetUsers();
            var filteredUsers = users.Where(u => u.Username != null && u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetUsersAsString(filteredUsers);
        }

        [McpServerTool, Description("Get users by role or group keyword (e.g. Driver, Coach, Fleet Read Only, or a group name like BC103)")]
        public async Task<string> GetUsersByRole(string roleKeyword)
        {
            var users = await GetUsers();
            var filteredUsers = users.Where(u => u.RolesGroup != null && u.RolesGroup.Contains(roleKeyword, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetUsersAsString(filteredUsers);
        }

        [McpServerTool, Description("Get users who have never logged in")]
        public async Task<string> GetUsersNeverLoggedIn()
        {
            var users = await GetUsers();
            var filteredUsers = users.Where(u => string.IsNullOrWhiteSpace(u.LastLoginDate)).ToList();
            return await GetUsersAsString(filteredUsers);
        }

        [McpServerTool, Description("Get users who have logged in at least once")]
        public async Task<string> GetUsersWhoHaveLoggedIn()
        {
            var users = await GetUsers();
            var filteredUsers = users.Where(u => !string.IsNullOrWhiteSpace(u.LastLoginDate)).ToList();
            return await GetUsersAsString(filteredUsers);
        }

        #endregion
    }
}
