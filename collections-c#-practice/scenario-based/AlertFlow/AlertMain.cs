using System;

namespace AlertFlow
{
    public class AlertMain
    {
        private readonly IAlertService _service;

        public AlertMain()
        {
            _service = new AlertServiceImplementation(workerCount: 3);
        }

        public void Run()
        {
            _service.StartProcessing();

            AlertMenu menu = new AlertMenu(_service);
            menu.Show();

            _service.StopProcessing();
        }
    }
}
