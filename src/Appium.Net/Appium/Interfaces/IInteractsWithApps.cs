﻿//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//See the NOTICE file distributed with this work for additional
//information regarding copyright ownership.
//You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.

namespace OpenQA.Selenium.Appium.Interfaces
{
    public interface IInteractsWithApps : IExecuteMethod
    {
        /// <summary>
        /// Installs an App.
        /// </summary>
        /// <param name="appPath">a string containing the file path or url of the app.</param>
        void InstallApp(string appPath);

        /// <summary>
        /// Launches the current app.
        /// </summary>
        void LaunchApp();

        /// <summary>
        /// Checks If an App Is Installed.
        /// </summary>
        /// <param name="appPath">a string containing the bundle id.</param>
        /// <return>a bol indicating if the app is installed.</return>
        bool IsAppInstalled(string bundleId);

        /// <summary>
        /// Resets the current app.
        /// </summary>
        void ResetApp();

        /// <summary>
        /// Deactivates app completely (as "Home" button does).  
        /// </summary>
        void BackgroundApp();

        /// <summary>
        /// Backgrounds the current app for the given number of seconds or deactivates app completely if negative number is given. 
        /// </summary>
        /// <param name="seconds">an integer number containing the number of seconds.</param>
        void BackgroundApp(int seconds);

        /// <summary>
        /// Removes an App.
        /// </summary>
        /// <param name="appPath">a string containing the id of the app.</param>
        void RemoveApp(string appId);

        /// <summary>
        /// Closes the current app.
        /// </summary>
        void CloseApp();

        /// <summary>
        /// Gets the State of the app.
        /// </summary>
        /// <param name="appId">a string containing the id of the app.</param>
        /// <returns>an integer number representing the status. 0 is not installed. 1 is not running. 2 is running in background or suspended. 3 is running in background. 4 is running in foreground.</returns>
        int GetAppState(string appId);
    }
}