using System;
using System.IO;

namespace AssetStudio
{
    [Flags]
    public enum LoggerEvent
    {
        None = 0,
        Verbose = 1,
        Debug = 2,
        Info = 4,
        Warning = 8,
        Error = 16,
        All = Verbose | Debug | Info | Warning | Error,
    }

    public interface ILogger
    {
        void Log(LoggerEvent loggerEvent, string message);
    }

    public sealed class DummyLogger : ILogger
    {
        public void Log(LoggerEvent loggerEvent, string message) { }
    }

    public sealed class ConsoleLogger : ILogger
    {
        public void Log(LoggerEvent loggerEvent, string message)
        {
            if (Logger.Flags.HasFlag(loggerEvent))
            {
                string chineseName = loggerEvent.GetChineseName();
                Console.WriteLine("[{0}] {1}", chineseName, message);
            }
        }
    }

    public sealed class FileLogger : ILogger
    {
        private const string LogFileName = "log.txt";
        private const string PrevLogFileName = "log_prev.txt";
        private readonly object LockWriter = new object();
        private StreamWriter Writer;
        public string logPath;
        public string prevLogPath;

        public FileLogger()
        {
            logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LogFileName);
            prevLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, PrevLogFileName);

            if (File.Exists(logPath))
            {
                File.Move(logPath, prevLogPath, true);
            }
            Writer = new StreamWriter(logPath, true) { AutoFlush = true };
        }
        ~FileLogger()
        {
            Dispose();
        }
        public void Log(LoggerEvent loggerEvent, string message)
        {
            if (Logger.Flags.HasFlag(loggerEvent))
            {
                lock (LockWriter)
                {
                    string chineseName = loggerEvent.GetChineseName();
                    Writer.WriteLine($"[{DateTime.Now}][{chineseName}] {message}");
                }
            }
        }

        public void Dispose()
        {
            Writer?.Dispose();
        }
    }
}