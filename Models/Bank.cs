using System.ComponentModel.DataAnnotations;

namespace ATMProject.Models
{
    public class Bank
    {
        [Key]
        public int BankID { get; set; }
        public string BankName { get; set; }
        public string Location { get; set; }
    }
}
