using System.Xml.Serialization;

public class LogAnalyzer
{
    public static void Start()
    {
        string[] logs = new string[] {  "2023-11-12 08:30:00 INFO Application started successfully",
                                        "2023-11-12 08:45:23 WARNING Low memory warning detected",
                                        "2023-11-12 09:15:45 ERROR Failed to connect to database",
                                        "2023-11-12 09:45:10 INFO User 'admin' logged in",
                                        "2023-11-12 10:00:00 ERROR Unexpected exception occurred",
                                        "2023-11-12 10:30:33 WARNING Disk space is almost full",
                                        "2023-11-12 11:00:05 INFO New user 'john_doe' created",
                                        "2023-11-12 11:30:00 INFO Scheduled maintenance started",
                                        "2023-11-12 12:00:00 ERROR Email service is not responding",
                                        "2023-11-12 12:30:45 WARNING High CPU usage detected"
                                     };

        foreach (string log in logs)
        {
            string date;
            string time;
            string level;
            string message;

            //Дата
            int dateStartIndex = 0;
            int dateEndIndex = log.IndexOf(" ");
            date = log.Substring(dateStartIndex, dateEndIndex);

            //Время
            int timeStartIndex = dateEndIndex + 1;
            int timeEndIndex = log.IndexOf(" ", timeStartIndex);
            time = log.Substring(timeStartIndex, timeEndIndex - dateEndIndex - 1);

            //Уровень
            int levelStartInndex = timeEndIndex + 1;
            int levelEndIndex = log.IndexOf(" ", levelStartInndex);

            level = log.Substring(levelStartInndex, levelEndIndex - timeEndIndex - 1);

            int messageStartIndex = levelEndIndex + 1;

            message = log.Substring(messageStartIndex);
            Console.WriteLine($"Дата: {date}, Время: {time}, Уровень: {(level + ",").PadRight(8)} Сообщение: {message}.");
        }
    }
}