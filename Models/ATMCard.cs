using System.ComponentModel.DataAnnotations;

namespace ATMProject.Models
{
    public class ATMCard
    {
        [Key]
        public int ATMCardID { get; set; }
        public string CardNumber { get; set; }
        public int UserID { get; set; }
    }
}
