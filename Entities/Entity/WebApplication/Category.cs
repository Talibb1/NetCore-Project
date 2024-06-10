using BaseLayer.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity.WebApplication
{
    public class Category:BaseEntity
    {
        public string Name { get; set; } = null!;
    }
}
