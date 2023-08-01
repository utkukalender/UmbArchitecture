using Core.Core.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umb.Application.Services.User;
using Umb.Domain;
using Umb.Persistance.Context;

namespace Umb.Persistance.Repositories
{
    public class UserRepository : EfCoreGenericRepository<User, ApplicationContext>,IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {

        }

    }
}
