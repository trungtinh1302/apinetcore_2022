using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class AccountCategory
    {
        public AccountCategory()
        {
            Accounts = new List<Account>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
