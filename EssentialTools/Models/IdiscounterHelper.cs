﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialTools.Models
{
    public interface IDiscounterHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }
}