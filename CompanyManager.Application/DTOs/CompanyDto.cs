using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager.Application.DTOs
{
    public record CompanyDto(Guid Id, string Name, string Address, string Phone, string Email);
}
