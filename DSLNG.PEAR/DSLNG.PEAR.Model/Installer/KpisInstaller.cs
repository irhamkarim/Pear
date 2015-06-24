﻿
using DSLNG.PEAR.Data.Entities;
using DSLNG.PEAR.Data.Persistence;
using System.Linq;
using System.Data.Entity;

namespace DSLNG.PEAR.Data.Installer
{
    public class KpisInstaller
    {
        private DataContext _context;
        public KpisInstaller(DataContext context)
        {
            _context = context;
        }
        public void Install() {
            var fatality = new Kpi
            {
                Id = 1,
                Name = "Fatality/Strap Disability",
                Measurement = _context.Measurements.Local.Where(x => x.Id == 1).First()
            };
            var securityIncident = new Kpi
            {
                Id = 2,
                Name = "Security Incident",
                Measurement = _context.Measurements.Local.Where(x => x.Id == 1).First()
            };
            _context.Kpis.Add(fatality);
            _context.Kpis.Add(securityIncident);
        }
    }
}