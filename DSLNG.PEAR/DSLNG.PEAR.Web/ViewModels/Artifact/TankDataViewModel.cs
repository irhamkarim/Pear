﻿

namespace DSLNG.PEAR.Web.ViewModels.Artifact
{
    public class TankDataViewModel
    {
        public string Title { get; set; }
        public string DaysToTankTopTitle { get; set; }
        public double VolumeInventory { get; set; }
        public string VolumeInventoryUnit { get; set; }
        public double DaysToTankTop { get; set; }
        public string DaysToTankTopUnit { get; set; }
        public double MinCapacity { get; set; }
        public double MaxCapacity { get; set; }
    }
}