using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STS.Infrastructure.Security
{
    public class Token
    {
        public string Secret { get; set; }
        public int ExpiracaoEmMinutos { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }


        public byte[] ObterChave()
        {
            return Encoding.ASCII.GetBytes(Secret);
        }
    }
}
