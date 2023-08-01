using Core.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umb.Domain
{
    public class User:AuditEntity
    {


        public string Name { get; set; }

        public User()
        {

        }
        public User(int id, string name, DateTime createdDate, DateTime? deletedTime, bool isDeleted)
        {
            Id= id;
            Name= name;
            CreatedTime= createdDate;
            DeletedTime= deletedTime;
            IsDeleted= isDeleted;

        }
    }
}
