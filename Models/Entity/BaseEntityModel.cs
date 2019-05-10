using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWebAPI.Models
{
    /// <summary>
    /// Base Model Class for all Model using Entity Framework DB Instance
    /// </summary>
    public class BaseEntityModel
    {
        /// <summary>
        /// Entity Framework Identification
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "bigint(20)")]
        public long ID { get; set; }

        /// <summary>
        /// Created data entry Date
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("create_dt", TypeName = "datetime(6)")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Last Updated data entry Date
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("update_dt", TypeName = "datetime(6)")]
        public DateTime UpdateDate { get; set; }
    }
}