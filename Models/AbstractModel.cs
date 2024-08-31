using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ToDoListApi.Models
{
    public class AbstractModel
    {
        [Required(ErrorMessage = "CreatedBy needs to be filled")]
        [Column("created_by")]
        public string CreatedBy { get; set; }

        [Required(ErrorMessage = "CreatedAt needs to be filled")]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "UpdatedBy needs to be filled")]
        [Column("updated_by")]
        public string UpdatedBy { get; set; }

        [Required(ErrorMessage = "UpdatedAt needs to be filled")]
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}