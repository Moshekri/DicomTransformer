﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DiconSCP
{
    public partial class DicomSCPSvc : ServiceBase
    {
        public DicomSCPSvc()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
        protected override void OnShutdown()
        {
            base.OnShutdown();
        }
        
    }
}
