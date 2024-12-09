using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewsWebsite.Models
{
    public class users
    {
        
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
           
            public int Id { get; set; }
        [Required]
        [Column("user name", TypeName = "Varchar(100)")]
      
       
        public string Username { get; set; }

        [Required]
        [Column("Email", TypeName = "Varchar(100)")]
      
            public string Email { get; set; }

        [Required]
        [Column("Password", TypeName = "Varchar(100)")]
            public string Password { get; set; }







        }
    }
