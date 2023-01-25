using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforms.Domain.Enums
{
    public enum ApproveStatus
    {
        [Display(Name = "Waiting")]
        Waiting = 0,

        [Display(Name = "Accepted")]
        Accepted = 1,

        [Display(Name = "Rejected")]
        Rejected = 2,
    }
}
