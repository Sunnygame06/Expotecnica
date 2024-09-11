using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Farmacia.Modelo.DTO
{
    public class DTOLogin : dbContext
    {
        private int id;
        private string Username;
        private string Password;
        private int Rol;
        private string pin;
        private string correo;
        public string Username1 { get => Username; set => Username = value; }
        public string Password1 { get => Password; set => Password = value; }
        public int Rol1 { get => Rol; set => Rol = value; }
        public int Id { get => id; set => id = value; }
        public string Pin { get => pin; set => pin = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}
