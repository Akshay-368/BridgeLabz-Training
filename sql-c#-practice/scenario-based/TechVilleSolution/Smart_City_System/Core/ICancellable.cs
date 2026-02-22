// File: Core/ICancellable.cs

namespace SmartCitySmartCity.Core
{
    // Defines cancellation behavior contract
    public interface ICancellable
    {
        void CancelService(string citizenName);
    }
}
