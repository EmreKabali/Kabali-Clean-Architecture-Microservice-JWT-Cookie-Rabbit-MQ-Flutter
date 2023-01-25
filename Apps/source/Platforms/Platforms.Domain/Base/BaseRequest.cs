using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Platforms.Domain.Base
{
    public class BaseRequest<T>
    {
        public T Entity { get; set; }

        public List<T> EntityList { get; set; }

        public DTO.Error Error { get; set; }
    }
}
