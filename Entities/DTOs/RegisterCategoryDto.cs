using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RegisterCategoryDto:IDto
    {
        public short Id { get; set; }

        [DefaultValue(false)]
        public bool CreatePermission  { get; set; }
        [DefaultValue(false)]
        public bool ExecutePermission  { get; set; }
    }
}
