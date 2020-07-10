using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entity.Client
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public virtual DateTimeOffset? LockoutEnd { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string ConcurrencyStamp { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual string NormalizedEmail { get; set; }
        public virtual string Email { get; set; }
        public virtual string NormalizedUserName { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Id { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual int AccessFailedCount { get; set; }

        public string Nome { get; set; }
        public string Endereco { get; set; }
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }
        public int OfficeID { get; set; }
        public int DepartmentID { get; set; }

        public virtual Office Office { get; set; }
        public virtual Department Department { get; set; }
    }
}
