using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceProcess;

namespace NetTaskManager_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost servicehost = new ServiceHost(typeof(TskMng));
            try
            {
                servicehost.Open();
                Console.WriteLine("Служба запущена\n");
                Console.WriteLine("Для завершения работы службы нажмите <ENTER>\n");
                Console.ReadLine();
                servicehost.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                servicehost.Abort();
            }
        }
    }
}
