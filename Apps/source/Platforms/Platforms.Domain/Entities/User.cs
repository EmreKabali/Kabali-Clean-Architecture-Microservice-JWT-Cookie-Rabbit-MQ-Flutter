using Platforms.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforms.Domain.Entities
{
    public class User:BaseEntity
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }

        public string Password { get; set; }
        public string Description { get; set; }

        public string Language { get; set; }

        public string Country { get; set; }

        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        public string AvatarPath { get; set; }

        public bool IsEmailValid { get; set; }
        public string EmailValidKey { get; set; }

        public string ActivationCode { get; set; }

        public DateTime? ActivationCodeExpireDate { get; set; }

        #region Foreign Keys
        public virtual ICollection<Right> Right { get; set; }


        #endregion
    }
}
