using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataModels
{
    public class PomiaryDlaPomDto
    {
        public int Id { get; set; }
        public int ZmiennaTempId { get; set; }
        public ZmienneTempDto ZmienneTemp { get; set;}
    }
}
