using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ToDoListApi.Models.Contracts;

namespace ToDoListApi.Models
{
    [Table("Items")]
    public class Item : AbstractModel, INameAndDescription
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "Item name cannot be empty")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("status_id")]
        [Required(ErrorMessage = "Item StatusId cannot be empty")]
        public string StatusId { get; set; }

        [Column("itemType_id")]
        [Required(ErrorMessage = "Item ItemTypeId cannot be empty")]
        public string ItemTypeId { get; set; }
    }
}