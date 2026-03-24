using System;

namespace HomeworkApp
{
    public static class CurrentUser
    {
        public static int UserId { get; set; } = -1;
        public static string Role { get; set; } = string.Empty;

        public static void Clear()
        {
            UserId = -1;
            Role = string.Empty;
        }
    }
}
