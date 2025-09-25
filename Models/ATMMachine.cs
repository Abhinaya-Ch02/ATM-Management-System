using System.ComponentModel.DataAnnotations;

namespace ATMProject.Models
{
    public class ATMMachine
    {
        [Key]
        public int ATMMachineID { get; set; }
        public string Location { get; set; }
        public int BankID { get; set; }
    }
}
