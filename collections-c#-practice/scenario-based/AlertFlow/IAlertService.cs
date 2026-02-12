namespace AlertFlow
{
    public interface IAlertService
    {
        void AddAlert(Alert notification);
        void StartProcessing();
        void StopProcessing();
        void DisplayAll();
    }
}
