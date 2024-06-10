using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity.Identity
{
    public class AppRole:IdentityRole<string>
    {
        [Timestamp]
        public byte[] RowVersion { get; set; } = null!;
    }
}
