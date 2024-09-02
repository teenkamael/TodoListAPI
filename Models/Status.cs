using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ToDoListApi.Models.Contracts;

namespace ToDoListApi.Models
{
    [Table("Status")]
    public class Status : AbstractModel, INameAndDescription
    {

        [Column("name")]
        [Required(ErrorMessage = "Status name cannot be empty")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public ICollection<ItemType> ItemTypes { get; set; }
    }
}