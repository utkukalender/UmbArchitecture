using Core.Core.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Umb.Application.Services.User
{
    public interface IUserRepository : IRepository<Umb.Domain.User>
    {
    }
}

