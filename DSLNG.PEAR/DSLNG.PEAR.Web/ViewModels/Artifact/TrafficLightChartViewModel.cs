﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSLNG.PEAR.Web.ViewModels.Artifact
{
    public class TrafficLightChartViewModel
    {
        public TrafficLightChartViewModel()
        {
            Series = new SeriesViewModel();
            PlotBands = new List<PlotBand>();
        }

        public SeriesViewModel Series { get; set; }
        public IList<PlotBand> PlotBands { get; set; }
        public class SeriesViewModel
        {
            [Display(Name = "Kpi")]
            public int KpiId { get; set; }
            public string KpiName { get; set; }
            public string Label { get; set; }
        }
        public class PlotBand
        {
            public double From { get; set; }
            public double To { get; set; }
            public string Color { get; set; }
            public string Label { get; set; }
        }
    }
}