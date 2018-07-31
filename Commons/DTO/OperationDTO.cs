using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Commons.DTO
{
    [Table("TblOperation")]
    public class OperationDTO
    {
        [Key]
        [IgnoreDataMember]
        public int IdPK { get; set; }
        [IgnoreDataMember]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Operation { get; set; }
        [Required]
        public string Calculation { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
