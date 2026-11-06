using System;

namespace ApplianceCenter
{
    //Base Class
    public abstract class HomeAppliance : IMaintainable
    {
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public double BaseRepairPrice { get; set; }
        public bool IsRepaired { get; protected set; }
          //Constructor
        public HomeAppliance(string serialNumber, string model, double baseRepairPrice)
        {
            SerialNumber = serialNumber;
            Model = model;
            BaseRepairPrice = baseRepairPrice;
            IsRepaired = false;
        }

        public virtual void StartMaintenance()
        {
            Console.WriteLine("بدأت عملية صيانة الجهاز ذو الرقم التسلسلي: " +SerialNumber);
        }

        public virtual void CompleteMaintenance()
        {
            IsRepaired = true;
            Console.WriteLine(" تمت صيانة الجهاز " + Model + "بنجاح.");
        }

        public abstract double CalculateRepairCost();
    }
}
// Refrigerator
    public class Refrigerator : HomeAppliance
    {
        public bool NeedsGasRefill { get; set; }

        public Refrigerator(string serialNumber, string model, double baseRepairPrice, bool needsGasRefill) 
            : base(serialNumber, model, baseRepairPrice)
        {
            NeedsGasRefill = needsGasRefill;
        }

        public override double CalculateRepairCost()
        {
            double gasCost = NeedsGasRefill ? 40.0 : 0.0;
            return BaseRepairPrice + gasCost;
        }
    }

    // Washing Machine
    public class WashingMachine : HomeAppliance
    {
        public bool NeedsDrumRepair { get; set; }

        public WashingMachine(string serialNumber, string model, double baseRepairPrice, bool needsDrumRepair) 
            : base(serialNumber, model, baseRepairPrice)
        {
            NeedsDrumRepair = needsDrumRepair;
        }

        public override double CalculateRepairCost()
        {
            double drumCost = NeedsDrumRepair ? 75.0 : 0.0;
            return BaseRepairPrice + drumCost;
        }
    }

    // Air Conditioner
    public class AirConditioner : HomeAppliance
    {
        public int CapacityHorsePower { get; set; }

        public AirConditioner(string serialNumber, string model, double baseRepairPrice, int capacityHorsePower) 
            : base(serialNumber, model, baseRepairPrice)
        {
            CapacityHorsePower = capacityHorsePower;
        }

        public override double CalculateRepairCost()
        {
            return BaseRepairPrice + (CapacityHorsePower * 30.0);
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            List<HomeAppliance> appliances = new List<HomeAppliance>
            {
                new Refrigerator("REF-101", "Samsung", 50.0, true),
                new WashingMachine("WM-202", "LG", 60.0, false),
                new AirConditioner("AC-303", "Gree", 80.0, 2)
            };

            double totalCost = 0;

            foreach (var app in appliances)
            {
                app.StartMaintenance();
                double cost = app.CalculateRepairCost();
                totalCost += cost;

                Console.WriteLine("Model: " + app.Model + " | Cost: " + cost);
                app.CompleteMaintenance();
                Console.WriteLine("-----------------------------------");
            }

            Console.WriteLine("Total Cost: " + totalCost);
        }
    }
}
