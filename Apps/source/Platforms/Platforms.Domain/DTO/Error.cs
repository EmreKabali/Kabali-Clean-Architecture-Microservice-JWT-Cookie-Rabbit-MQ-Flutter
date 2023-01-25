﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforms.Domain.DTO
{
    public class Error
    {
        public bool HasException { get; set; } = false;

        public int Code { get; set; }

        public string Message { get; set; }

    }
}
