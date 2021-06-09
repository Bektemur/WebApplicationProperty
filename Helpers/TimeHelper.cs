using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProperty.Helpers
{
    public static class TimeHelper
    {
        public static string GetRelativeDateTime(DateTime date)
        {
            TimeSpan ts = DateTime.UtcNow - date;
            if (ts.TotalMinutes < 1)//seconds ago
                return "just now";
            if (ts.TotalHours < 1)//min ago
                return (int)ts.TotalMinutes == 1 ? "1 Minute ago" : (int)ts.TotalMinutes + " Minutes ago";
            if (ts.TotalDays < 1)//hours ago
                return (int)ts.TotalHours == 1 ? "1 Hour ago" : (int)ts.TotalHours + " Hours ago";
            if (ts.TotalDays < 7)//days ago
                return (int)ts.TotalDays == 1 ? "1 Day ago" : (int)ts.TotalDays + " Days ago";
            if (ts.TotalDays < 30.4368)//weeks ago
                return (int)(ts.TotalDays / 7) == 1 ? "1 Week ago" : (int)(ts.TotalDays / 7) + " Weeks ago";
            if (ts.TotalDays < 365.242)//months ago
                return (int)(ts.TotalDays / 30.4368) == 1 ? "1 Month ago" : (int)(ts.TotalDays / 30.4368) + " Months ago";
            //years ago
            return (int)(ts.TotalDays / 365.242) == 1 ? "1 Year ago" : (int)(ts.TotalDays / 365.242) + " Years ago";
        }
    }
}
