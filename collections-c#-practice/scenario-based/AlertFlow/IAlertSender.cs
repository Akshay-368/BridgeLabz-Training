using System.Threading.Tasks;

namespace AlertFlow
{
    public interface IAlertSender
    {
        Task SendAsync(Alert notification);
    }
}
