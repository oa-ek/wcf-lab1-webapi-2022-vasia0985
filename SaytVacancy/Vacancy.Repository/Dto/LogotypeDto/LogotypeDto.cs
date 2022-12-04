using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Core;

namespace Vacancy.Repository.Dto.LogotypeDto
{
    public class LogotypeDto
    {
        public int LogotypeId { get; set; }
        public string? LogotypeName { get; set; }

        public virtual ICollection<Company>? Companies { get; set; }
    }
}
