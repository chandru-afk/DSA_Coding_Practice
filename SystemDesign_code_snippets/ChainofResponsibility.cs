using System;

public abstract class LogProcessor
{
    public static int Info = 1;
    public static int Debug = 2;
    public static int Error = 3;

    protected LogProcessor NextLogProcessor;

    public LogProcessor(LogProcessor next)
    {
        this.NextLogProcessor = next;
    }

    public virtual void Log(int logLevel, string message)
    {
        if (NextLogProcessor != null)
            NextLogProcessor.Log(logLevel, message);
    }
}

public class LoggerInfo : LogProcessor
{
    public LoggerInfo(LogProcessor next) : base(next) { }

    public override void Log(int logLevel, string message)
    {
        if (logLevel == Info)
            Console.WriteLine("Log level Info: " + message);
        else
            base.Log(logLevel, message);
    }
}

public class LoggerError : LogProcessor
{
    public LoggerError(LogProcessor next) : base(next) { }

    public override void Log(int logLevel, string message)
    {
        if (logLevel == Error)
            Console.WriteLine("Log level Error: " + message);
        else
            base.Log(logLevel, message);
    }
}

public class Program
{
    public static void Main()
    {
        // Set up the chain: Error -> Info
        LogProcessor logger = new LoggerError(new LoggerInfo(null));

        logger.Log(LogProcessor.Info, "This is an info message.");
        logger.Log(LogProcessor.Error, "This is an error message.");
    }
}
