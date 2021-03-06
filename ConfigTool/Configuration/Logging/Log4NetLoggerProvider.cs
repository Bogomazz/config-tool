using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace ConfigTool.Configuration.Logging
{
  public class Log4NetLoggerProvider : ILoggerProvider, IDisposable
  {
    private readonly ConcurrentDictionary<string, Log4NetAppStartErrorLogger> _loggers = new ConcurrentDictionary<string, Log4NetAppStartErrorLogger>();

    public ILogger CreateLogger(string categoryName)
    {
      return (ILogger) _loggers.GetOrAdd(categoryName, new Log4NetAppStartErrorLogger(categoryName));
    }

    public void Dispose()
    {
      _loggers.Clear();
    }
  }
}