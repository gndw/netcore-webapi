using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWebAPI.Models
{
    public abstract class EntityModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "bigint(20)")]
        public long ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("create_dt", TypeName = "datetime(6)")]
        public DateTime CreateDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("update_dt", TypeName = "datetime(6)")]
        public DateTime UpdateDate { get; set; }
    }
}