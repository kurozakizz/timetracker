using System;
using Xunit;

namespace timetracker
{
    public class TimeTrackerTest
    {
        [Fact]
        public void WhenTimeEqualShouldReturn0 () 
        {
          int expected = 0;
          TimeSpan t1 = new TimeSpan(8, 0, 0);
          TimeSpan t2 = new TimeSpan(8, 0, 0);

          int result = TimeSpan.Compare(t1, t2);

          Assert.Equal(expected, result);
        }

        [Fact]
        public void WhenT1LessthanT2ShouldReturnMinus1 () 
        {
          int expected = -1;
          TimeSpan t1 = new TimeSpan(8, 0, 0);
          TimeSpan t2 = new TimeSpan(9, 0, 0);

          int result = TimeSpan.Compare(t1, t2);

          Assert.Equal(expected, result);
        }

        [Fact]
        public void WhenT1MorethanT2ShouldReturnPlus1 () 
        {
          int expected = 1;
          TimeSpan t1 = new TimeSpan(9, 0, 0);
          TimeSpan t2 = new TimeSpan(8, 0, 0);

          int result = TimeSpan.Compare(t1, t2);

          Assert.Equal(expected, result);
        }

        [Fact]
        public void when0800ShouldOpen()
        {
          bool expected = true;
          TimeSpan time0800 = new TimeSpan(8, 0, 0);
          TimeTracker timeTracker = new TimeTracker(time0800);
          
          bool result = timeTracker.isOpen();

          Assert.Equal(expected, result);
        }

        [Fact]
        public void when1700ShouldOpen()
        {
          bool expected = true;
          TimeSpan time1700 = new TimeSpan(17, 0, 0);
          TimeTracker timeTracker = new TimeTracker(time1700);

          bool result = timeTracker.isOpen();

          Assert.Equal(expected, result);
        }

        [Fact]
        public void when1701ShouldClose()
        {
          bool expected = false;
          TimeSpan time1701 = new TimeSpan(17, 1, 0);
          TimeTracker timeTracker = new TimeTracker(time1701);

          bool result = timeTracker.isOpen();

          Assert.Equal(expected, result);
        }

        [Fact]
        public void when0759ShouldClose()
        {
          bool expected = false;
          
          TimeSpan time0759 = new TimeSpan(7, 59, 0);
          TimeTracker timeTracker = new TimeTracker(time0759);
          bool result = timeTracker.isOpen();

          Assert.Equal(expected, result);
        }

        [Fact]
        public void loggerIsExecuted()
        {
          TimeTracker timeTracker = new TimeTracker();
          MockLogger logger = new MockLogger();
          timeTracker.setLogger(logger);

          timeTracker.isOpen();

          Assert.Equal(logger.writeCount, 1);
        }

        [Fact]
        public void logContentIsCurrentTime(){
          TimeSpan time0800 = new TimeSpan(8, 0, 0);
          TimeTracker timeTracker = new TimeTracker(time0800);
          MockLogger logger = new MockLogger();
          timeTracker.setLogger(logger);

          timeTracker.isOpen();

          Assert.Equal(logger.writeContent, time0800.ToString());
        }
    }
}
