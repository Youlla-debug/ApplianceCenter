using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplianceCenter
{

    // Maintenance interface
    public interface IMaintainable
    {
        void StartMaintenance();
        void CompleteMaintenance();
    }

    // Abstract class
    public abstract partial class HomeAppliance : IMaintainable
    {
        // Abstract method
        public abstract double CalculateRepairCost();

        public virtual void StartMaintenance()
        {
            Console.WriteLine("Maintenance started for serial number: " + SerialNumber);
        }

        public virtual void CompleteMaintenance()
        {
            IsRepaired = true;
            Console.WriteLine("Maintenance completed for model: " + Model);
        }
    }// Refrigerator class
    public class Refrigerator : HomeAppliance
    {
        public bool NeedsGasRefill { get; set; }

        public Refrigerator(string serialNumber, string model, double baseRepairPrice, bool needsGasRefill)
            : base(serialNumber, model, baseRepairPrice)
        {
            NeedsGasRefill = needsGasRefill;
        }

        // Override cost
        public override double CalculateRepairCost()
        {
            double gasCost = NeedsGasRefill ? 40.0 : 0.0;
            return BaseRepairPrice + gasCost;
        }
    }

    // WashingMachine class
    public class WashingMachine : HomeAppliance
    {
        public bool NeedsDrumRepair { get; set; }

        public WashingMachine(string serialNumber, string model, double baseRepairPrice, bool needsDrumRepair)
            : base(serialNumber, model, baseRepairPrice)
        {
            NeedsDrumRepair = needsDrumRepair;
        }

        // Override cost
        public override double CalculateRepairCost()
        {
            double drumCost = NeedsDrumRepair ? 75.0 : 0.0;
            return BaseRepairPrice + drumCost;
        }
    }

    // AirConditioner class
    public class AirConditioner : HomeAppliance
    {
        public int CapacityHorsePower { get; set; }

        public AirConditioner(string serialNumber, string model, double baseRepairPrice, int capacityHorsePower)
            : base(serialNumber, model, baseRepairPrice)
        {
            CapacityHorsePower = capacityHorsePower;
        }

        // Override cost
        public override double CalculateRepairCost()
        {
            return BaseRepairPrice + (CapacityHorsePower * 30.0);
        }
    }
