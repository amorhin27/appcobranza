using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Models.EmailModels
{
    public class EmailSettings
    {
        public string? Apikey { get; set; }
        public string? FromAddress { get; set; }
        public string? FromName { get; set; }
    }
}
