using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetTaskManager_Service
{
    public class TskMng : ITskMng
    {
        public String[] GetProcesses()
        {
            List<string> list = new List<string>();
            var processes = Process.GetProcesses();
            foreach(var p in processes)
            {
                list.Add(p.ProcessName);
            }
            return list.ToArray();
        }

        public int KillTask(string name)
        {
            try
            {
                var proc = Process.GetProcessesByName(name);
                foreach (var p in proc)
                {
                    p.Kill();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            return 1;
        }
        public int RunTask(string name)
        {
            try
            {
                Process.Start(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            return 1;
        }
        public string Hello()
        {
            return "Hello!";
        }
    }
}
