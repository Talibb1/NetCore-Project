using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity.Identity
{
    public class AppUser:IdentityUser
    {
        public bool Status { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; } = null!;

    }
}
