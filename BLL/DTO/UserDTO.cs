using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public override string ToString()
        {
            return $"UserDTO(Id: {Id}, Login: {Login})";
        }
    }
}
