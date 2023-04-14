using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CategoryForUserIdDto:IDto
    {
        public short Id { get; set; }

        public bool ExecutePermisson { get; set; }
        public bool CreatePermisson { get; set; }
    }
}
