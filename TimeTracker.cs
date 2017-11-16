
using System;

namespace timetracker
{
  public class TimeTracker
  {
    TimeSpan currentTime = DateTime.Now.TimeOfDay;
    TimeSpan openTime = new TimeSpan(8, 0, 0);
    TimeSpan closeTime = new TimeSpan(17, 0, 0);

    Logger logger = new Logger();

    public TimeTracker ()
    {
    }

    public TimeTracker (TimeSpan currentTime)
    {
      this.currentTime = currentTime;
    }

    internal bool isOpen()
    {
      logger.write(currentTime.ToString());
      return TimeSpan.Compare(currentTime, openTime) >= 0 && TimeSpan.Compare(currentTime, closeTime) <= 0;
    }

    internal void setLogger(Logger logger)
    {
      this.logger = logger;
    }
  }
}