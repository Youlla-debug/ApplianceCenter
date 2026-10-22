using System;

namespace ApplianceCenter
{
    public abstract class HomeAppliance : IMaintainable
    {
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public double BaseRepairPrice { get; set; }
        public bool IsRepaired { get; protected set; }

        public HomeAppliance(string serialNumber, string model, double baseRepairPrice)
        {
            SerialNumber = serialNumber;
            Model = model;
            BaseRepairPrice = baseRepairPrice;
            IsRepaired = false;
        }

        public virtual void StartMaintenance()
        {
            Console.WriteLine($"بدأت عملية صيانة الجهاز ذو الرقم التسلسلي: {SerialNumber}");
        }

        public virtual void CompleteMaintenance()
        {
            IsRepaired = true;
            Console.WriteLine($"تمت صيانة الجهاز {Model} بنجاح.");
        }

        public abstract double CalculateRepairCost();
    }
}
