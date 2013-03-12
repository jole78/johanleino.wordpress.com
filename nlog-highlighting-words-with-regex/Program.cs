using System;
using System.Collections.Generic;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace JL
{
    class Program
    {
        private static readonly Logger m_Logger;
        private static readonly List<string> m_Tasks; 

        static Program()
        {
            m_Logger = LogManager.GetCurrentClassLogger();
            m_Tasks = new List<string>
                      {
                          "backup",
                          "updating",
                          "verifying",
                          "finishing"
                      };

            ConfigureLogger();
        }

        static void Main(string[] args)
        {
            int i = 1;
            foreach (var task in m_Tasks)
            {
                ExecuteTask(task, i, m_Tasks.Count);
                i++;
            }

            Console.Read();
        }

        private static void ExecuteTask(string task, int seed, int total)
        {
            m_Logger.Info(" - now running deployment task {0}/{1} with name='{2}'", seed, total, task);
        }

        static void ConfigureLogger()
        {
            var configuration = new LoggingConfiguration();

            var target = new ColoredConsoleTarget();
            configuration.AddTarget("console", target);

            target.Layout = "${message}";

            target.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule
                {
                    Condition = "level == LogLevel.Info",
                    ForegroundColor = ConsoleOutputColor.Green
                });
            target.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule
                {
                    Condition = "level == LogLevel.Debug",
                    ForegroundColor = ConsoleOutputColor.White
                });
            target.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule
                {
                    Condition = "level == LogLevel.Error",
                    ForegroundColor = ConsoleOutputColor.Red
                });
            target.RowHighlightingRules.Add(
                new ConsoleRowHighlightingRule
                {
                    Condition = "level == LogLevel.Warn",
                    ForegroundColor = ConsoleOutputColor.Yellow
                });

            target.WordHighlightingRules.Add(
                new ConsoleWordHighlightingRule
                {
                    Regex = "name='[^']*'",
                    ForegroundColor = ConsoleOutputColor.Yellow
                });

            LoggingRule rule1 = new LoggingRule("*", LogLevel.Debug, target);
            configuration.LoggingRules.Add(rule1);
            
            LogManager.Configuration = configuration;
        }
    }
}
