using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ToDoListApi.Models.Contracts;

namespace ToDoListApi.Models
{
    [Table("ItemTypes")]
    public class ItemType : AbstractModel, INameAndDescription
    {

        [Column("name")]
        [Required(ErrorMessage = "ItemType name cannot be empty")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public ICollection<Status> RelatedStatus { get; set; }
    }
}