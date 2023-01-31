using System;
using System.ComponentModel.DataAnnotations;

namespace Platforms.Domain.DTO.Account
{
	public class LoginDTO
	{
		[Required(ErrorMessage ="Email field is required")]
		[EmailAddress(ErrorMessage ="Please input email format")]
		public string Email { get; set; }
		[Required(ErrorMessage ="Password field is required")]
		public string Password { get; set; }

	}
}

