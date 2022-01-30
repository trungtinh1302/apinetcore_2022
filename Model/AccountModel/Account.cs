using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class Account
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public int Gender { get; set; } // 0: giới tính thứ 3, 1: nam, 2: nữ
        public bool Status { get; set; }
        public DateTime CreatedTime { get; set; }
        [ForeignKey("AccountCategory")]
        public int AccountCatetoryID { get; set; }
        public AccountCategory AccountCategory { get; set; }
    }
}
