using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforms.Domain.Enums
{
    public enum Status
    {
        [Display(Name = "Passive")]
        Passive = 0,

        [Display(Name = "Active")]
        Active = 1,

        [Display(Name = "Deleted")]
        Deleted = 2,

    }
}
