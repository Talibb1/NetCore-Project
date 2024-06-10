using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.BaseEntity
{
    public class BaseEntity
    {

        public int Id { get; set; }

        public byte[] RowVersion { get; set; } = null!;



    }
}
