namespace SmartCitySmartCity.Models
{
    public class PremiumHealthcareService : HealthcareService
    {
        public double PremiumFee { get; }

        public PremiumHealthcareService(double baseCost, bool emergencySupport, double premiumFee)
            : base(baseCost, emergencySupport)   // using base keyword
        {
            this.PremiumFee = premiumFee;
            this.BaseCost += premiumFee;
        }

        public override void DisplayServiceInfo()
        {
            base.DisplayServiceInfo();
            Console.WriteLine($"Premium Fee: {PremiumFee}");
        }
    }
}
