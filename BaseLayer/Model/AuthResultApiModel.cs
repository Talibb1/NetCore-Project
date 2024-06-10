using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Model
{
    public class AuthResultApiModel
    {
        public bool Error { get; set; }

        public string Message { get; set; } = null!;

        public string Token { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Id { get; set; } = null!;


    }
}
