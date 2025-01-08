using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Cleaner
{
    internal class TemporaryFilesAction : ITaskHandler
    {
        public void Start(object pHandlerServices, string data)
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new BasicTemporaryRemover());
        }

        public void Stop(out int pRetCode)
        {
            Application.Exit();
            pRetCode = 0;
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }
    }
}
