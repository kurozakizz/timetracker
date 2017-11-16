using System;

namespace timetracker
{
  public class Logger
  {
    public virtual void write(String lines)
    {
      string filePath = "F:\\Work\\sck\\labs\\pboy\\timetracker\\real.txt";
      System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true);
      file.WriteLine(lines);
      file.Close();
    }
  }
}