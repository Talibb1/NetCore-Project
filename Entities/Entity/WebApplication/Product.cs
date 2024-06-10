using BaseLayer.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity.WebApplication
{
    public class Product:BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int CatId { get; set; }


        public Category? Category { get; set; } 


    }
}
