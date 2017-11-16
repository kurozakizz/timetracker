using System;

namespace timetracker
{
  public class MockLogger : Logger
  {
    public int writeCount = 0;
    public String writeContent = "";
    public override void write(String lines)
    {
      writeContent = lines;
      writeCount++;
    }
  }
}