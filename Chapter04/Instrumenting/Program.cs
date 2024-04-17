using System.Diagnostics;
using static System.Console;

string logPath = Path.Combine(
    Environment.GetFolderPath(
        Environment.SpecialFolder.DesktopDirectory), "logPath.txt");

WriteLine($"Writing to: {logPath}");
TextWriterTraceListener logFile = new(File.CreateText(logPath));
Trace.Listeners.Add(logFile);

//txt writer is buffered, so this option calls
//Flush() on all listeners after writing
Trace.AutoFlush = true;


Debug.WriteLine("Debug says, I am watching");
Trace.WriteLine("Trace says, I am watching");