﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLNG.PEAR.Services.Requests.Measurement
{
    public class GetMeasurementRequest
    {
        public int Id { get; set; }
    }

    public class GetMeasurementsRequest {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
