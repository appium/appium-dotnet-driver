﻿using System;
using System.Collections.Generic;
using System.IO;
using integration_tests.Properties;

namespace Appium.Integration.Tests.Helpers
{
    public class Apps
    {
        private static bool _isInited;
        private static Dictionary<string, string> _testApps;

        private static string _testAppsDir = $"{AppDomain.CurrentDomain.BaseDirectory}..//..//..//apps";

        private static void Init()
        {
            if (!_isInited)
            {
                if (Env.ServerIsRemote())
                {
                    _testApps = new Dictionary<string, string>
                    {
                        {"iosTestApp", "https://github.com/akinsolb/appium-dotnet-driver/blob/update-test-apps/integration_tests/apps/TestApp.app.zip?raw=true"},
                        {"intentApp", "https://github.com/akinsolb/appium-dotnet-driver/blob/update-test-apps/integration_tests/apps/IntentExample.zip?raw=true"},
                        {"iosWebviewApp", "https://github.com/akinsolb/appium-dotnet-driver/blob/update-test-apps/integration_tests/apps/WebViewApp.app.zip?raw=true"},
                        {"iosUICatalogApp", "https://github.com/akinsolb/appium-dotnet-driver/blob/update-test-apps/integration_tests/apps/UICatalog.app.zip?raw=true"},
                        {"androidApiDemos", "https://github.com/akinsolb/appium-dotnet-driver/blob/update-test-apps/integration_tests/apps/ApiDemos-debug.zip?raw=true"},
                        {"vodqaApp", "https://github.com/akinsolb/appium-dotnet-driver/blob/update-test-apps/integration_tests/apps/vodqa.zip?raw=true"}
                    };
                }
                else
                {
                    var tempFolder = Path.GetTempPath();

                    File.WriteAllBytes($"{tempFolder}/ApiDemos-debug.apk", Resources.ApiDemos_debug);
                    File.WriteAllBytes($"{tempFolder}/TestApp.app.zip", Resources.TestApp_app);
                    File.WriteAllBytes($"{tempFolder}/WebViewApp.app.zip", Resources.WebViewApp_app);
                    File.WriteAllBytes($"{tempFolder}/UICatalog.app.zip", Resources.UICatalog_app);
                    File.WriteAllBytes($"{tempFolder}/IntentExample.apk", Resources.IntentExample);
                    File.WriteAllBytes($"{tempFolder}/vodqa.app.zip", Resources.vodqa);





                    _testApps = new Dictionary<string, string>
                    {
                        {"iosTestApp", new FileInfo($"{Path.GetTempPath()}/TestApp.app.zip").FullName},
                        {"intentApp", new FileInfo($"{Path.GetTempPath()}/IntentExample.apk").FullName},
                        {"iosWebviewApp", new FileInfo($"{Path.GetTempPath()}//WebViewApp.app.zip").FullName},
                        {"iosUICatalogApp", new FileInfo($"{Path.GetTempPath()}/UICatalog.app.zip").FullName},
                        {"androidApiDemos", new FileInfo($"{Path.GetTempPath()}/ApiDemos-debug.apk").FullName},
                        {"vodqaApp", new FileInfo($"{Path.GetTempPath()}/vodqa.app.zip").FullName}

                    };
                }
                _isInited = true;
            }
        }

        public static string get(string appKey)
        {
            Init();
            return _testApps[appKey];
        }
    }
}