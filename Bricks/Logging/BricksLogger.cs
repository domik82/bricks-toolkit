using System;
using System.IO;
using log4net;
using log4net.Config;

namespace Bricks.Logging
{
    public class BricksLogger
    {
        protected BricksLogger()
        {
            if (!LogManager.GetRepository().Configured)
            {
                string log4NetFilePath = ConfigFile();
                if (File.Exists(log4NetFilePath))
                {
                    var configFile = new FileInfo(log4NetFilePath);
                    XmlConfigurator.ConfigureAndWatch(configFile);
                    CoreLogger.Instance.Info(
                        string.Format("BricksLogger - log4net configured using default config file ({0})", configFile));
                }
                else
                    Console.Error.WriteLine("BricksLogger - Log4Net is not configured. Looked for default config file: {0}",
                                            new FileInfo(log4NetFilePath).FullName);
            }
            else
            {
                CoreLogger.Instance.Info("BricksLogger - log4net already configured.");
            }
        }

        protected virtual string ConfigFile()
        {
            return @"log4net.config";
        }
    }
}