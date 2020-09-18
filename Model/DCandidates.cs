using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class DCandidates
    {
        [Key]
   
        public int id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string fullname { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string mobile { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; }
        [Column(TypeName = "nvarchar(100)")]

        public string age { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string bloodgroup { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string address { get; set; }
    }
}
