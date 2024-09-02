using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ToDoListApi.Models.Contracts;

namespace ToDoListApi.Models{
    [Table("StatusItemTypes")]
    public class StatusItemType : AbstractModel
    {
        [Column("status_id")]
        [Required(ErrorMessage = "StatusItemType StatusId cannot be empty")]
        public int StatusId { get; set; }


        [Column("itemType_id")]
        [Required(ErrorMessage = "StatusItemType ItemTypeId cannot be empty")]
        public int ItemTypeId { get; set; }


        [Column("enabled")]
        public bool Enabled { get; set; }
    }
}