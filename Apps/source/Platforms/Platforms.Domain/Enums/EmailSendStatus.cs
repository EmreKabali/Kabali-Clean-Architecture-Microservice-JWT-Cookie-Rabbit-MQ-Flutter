using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforms.Domain.Enums
{
    public enum EmailSendStatus
    {
        [Display(Name = "Waiting")]
        Waiting = 0,

        [Display(Name = "Success")]
        Success = 1,
    }
}
