
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment:IEntity
    {
        public int Id { get; set; }
        public string  Text { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public int RequestId { get; set; }
        public int? CFileId { get; set; }

        public User User { get; set; }
        public Request Request { get; set; }
        public File File { get; set; }
    }
}
