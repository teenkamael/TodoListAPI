using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ToDoListApi.Models
{
    public class AbstractModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "CreatedBy needs to be filled")]
        [Column("created_by")]
        public virtual string CreatedBy { get; set; }

        [Required(ErrorMessage = "CreatedAt needs to be filled")]
        [Column("created_at")]
        public virtual DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "UpdatedBy needs to be filled")]
        [Column("updated_by")]
        public virtual string UpdatedBy { get; set; }

        [Required(ErrorMessage = "UpdatedAt needs to be filled")]
        [Column("updated_at")]
        public virtual DateTime UpdatedAt { get; set; }
    }
}