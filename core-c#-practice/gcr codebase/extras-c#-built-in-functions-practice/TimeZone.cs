using System;
public static class TimeZone
{
    public static void Main()
    {
        /* 1. Problem 1: Time Zones and DateTimeOffset
        Write a program that displays the current time in different time zones:
        ● GMT (Greenwich Mean Time)
        ● IST (Indian Standard Time)
        ● PST (Pacific Standard Time)
        Hint: Use DateTimeOffset and TimeZoneInfo to work with different time zones. */

        // current UTC time
        DateTimeOffset utcNow = DateTimeOffset.UtcNow;
        // DateTimeOffset represents a date and time with an offset from UTC , so Date + Time + UTC offset
        // utc now means Current time in UTC - universal coordinated time , which is a primary time standard that regulates clocks adn times
        // We can also call it as Greenwich Mean Time


        // Converting it to IST ( Indian Standard Time )
        var istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        var ist = TimeZoneInfo.ConvertTime(utcNow, istZone);
        // TimeZoneInfo is a class that represents a time zone like ist and pst and provides methods to convert between different time zones
        // and we just fetch it using system time id as per the zones

        // Converting it to PST
        var pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        var pst = TimeZoneInfo.ConvertTime(utcNow, pstZone);
        // ConvertTime - Converts a DateTimeOffset or DateTime from one zone to another


        Console.WriteLine($"UTC/GMT: {utcNow}");
        Console.WriteLine($"IST: {ist}");
        Console.WriteLine($"PST: {pst}");
        
    }
}
