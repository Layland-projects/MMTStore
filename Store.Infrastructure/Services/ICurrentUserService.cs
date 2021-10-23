using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Services
{
    public interface ICurrentUserService
    {
        string Username { get; }
    }
}
