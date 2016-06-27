using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Spectrum.WinService
{
    public class SpectrumBackstage : ServiceControl
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private IBusControl _busControl;
        private BusHandle _busHandle;

        public SpectrumBackstage(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public bool Start(HostControl hostControl)
        {
            _busHandle = _busControl.Start();

            logger.Info("Backstage Started");

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            if (_busHandle != null)
                _busHandle.Stop();

            logger.Info("Backstage Stopped");

            return true;
        }
    }
}
