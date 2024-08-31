using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ToDoListApi.Models.Contracts;

namespace ToDoListApi.Models{
    [Table("StatusItemTypes")]
    public class StatusItemType : AbstractModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("status_id")]
        [Required(ErrorMessage = "StatusItemType StatusId cannot be empty")]
        public string StatusId { get; set; }


        [Column("itemType_id")]
        [Required(ErrorMessage = "StatusItemType ItemTypeId cannot be empty")]
        public string ItemTypeId { get; set; }


        [Column("enabled")]
        public string Enabled { get; set; }
    }
}