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
    }
