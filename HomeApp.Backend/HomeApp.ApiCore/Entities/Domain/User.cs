using System;
using System.ComponentModel.DataAnnotations;

namespace HomeApp.ApiCore.Entities.Domain
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Guid? PublicId { get; set; }
        [Required, StringLength(15)]
        public string UserName { get; set; }
        [Required] 
        public string UserEmail { get; set; }
        [Required] 
        public string UserPhone { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
    }
}
