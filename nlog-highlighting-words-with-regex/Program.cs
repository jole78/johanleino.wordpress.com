using System;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace JL
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureLogger();
            var logger = LogManager.GetCurrentClassLogger();

            logger.Info(" - now running deployment task {0}/{1} with name='{2}'", 1, 10, "backup");

            Console.Read();
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
