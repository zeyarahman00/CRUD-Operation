using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LPInfotech.Models
{
    [Table("Setting", Schema = "dbo")]
    public class Setting
    {
        public Int64 Id { get; set; }

        [Required(ErrorMessage = "Key Is required!")]
        public string Key { get; set; } = "";

        [Required(ErrorMessage = "Value Is required!")]
        public string Value {get;set;} = "";

        [Required(ErrorMessage = "Value2 Is required!")]
        public string Value2 {get;set;} = "";

        [Required(ErrorMessage = "Description Is required!")]
        public string Description {get;set;} = "";
        public DateTime Created {get;set;} = DateTime.Now;
        public DateTime LastModified {get;set;} = DateTime.Now;
        public bool IsDeleted {get;set;} = false;
    }
}
