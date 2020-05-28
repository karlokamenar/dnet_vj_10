using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dnet_vj_10_servis
{
    public partial class dnet_vj_10_servis : ServiceBase
    {
        bool stop = false;
        EventLog log = new EventLog();
        public dnet_vj_10_servis()
        {
            InitializeComponent();
            if (!EventLog.SourceExists("dnet_vj_10_servis"))
            {
                EventSourceCreationData logIzvorPodaci = new EventSourceCreationData("dnet_vj_10_servis", "Application");
                EventLog.CreateEventSource(logIzvorPodaci);
            }
            log.Source = "dnet_vj_10_servis";
            log.Log = "Application";
        }

        protected override void OnStart(string[] args)
        {
            WaitCallback callbackDelegate = (state) =>   
            {
                while (!stop)
                {
                    log.WriteEntry("Nešto radim... ");
                    Thread.Sleep(10000);
                }
            };

            ThreadPool.QueueUserWorkItem(callbackDelegate);
        }

        protected override void OnStop()
        {
            stop = true;
        }
    }
}
