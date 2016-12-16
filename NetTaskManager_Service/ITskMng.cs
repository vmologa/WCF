using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceProcess;
using System.Diagnostics;

namespace NetTaskManager_Service
{
    [ServiceContract]
    public interface ITskMng
    {
        [OperationContract]
        String[] GetProcesses();//возвращает список процессов на устройстве
        [OperationContract]
        int KillTask(string name);
        [OperationContract]
        int RunTask(string name);
        [OperationContract]
        string Hello();
    }
}
