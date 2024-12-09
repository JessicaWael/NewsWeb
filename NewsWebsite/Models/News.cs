using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewsWebsite.Models
{
    public class News
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        public string Title{ get; set; }
        
        public string Topic { get; set; }
       // [Column("Image", TypeName = "Varchar(100)")]
        public string Image { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
    }
}
