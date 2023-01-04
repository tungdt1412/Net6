﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_6.Common.Shared.Model
{
    public class BaseError
    {
        public string? Code { get; set; } = string.Empty;
        public string? RelatedProperties { get; set; } = string.Empty;
        public string? Message { get; set; } = string.Empty;
    }
}
