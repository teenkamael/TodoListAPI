using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListApi.Models{
    [Table("Users")]
    public class User : AbstractModel
    {

        [Required(ErrorMessage = "User name cannot be empty")]
        [Column("name")]
        public string Name { get; set; }

        [Column("surname")]
        public string Surname {get;set;}

        [Required(ErrorMessage = "User username cannot be empty")]
        [Column("username")]
        public string Username {get;set;}

        [Column("password")]
        public string Password {get;set;}
        
    }
}