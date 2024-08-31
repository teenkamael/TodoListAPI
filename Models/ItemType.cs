using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ToDoListApi.Models.Contracts;

namespace ToDoListApi.Models
{
    [Table("ItemTypes")]
    public class ItemType : AbstractModel, INameAndDescription
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "ItemType name cannot be empty")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public IEnumerable<Status> RelatedStatus { get; set; }
    }
}