using System.ComponentModel.DataAnnotations;

namespace Assignment_No._04_VP_LAB.Application_02
{
    public class UserProfileModel
    {
		[Required(ErrorMessage = "First designation handle moniker is strictly required.")]
		[StringLength(20, ErrorMessage = "First name configuration length constraint breached.")]
		public string FirstName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Last designation handle moniker is strictly required.")]
		public string LastName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Operational endpoint contact routing email is mandatory.")]
		[EmailAddress(ErrorMessage = "Input parameters fail to conform to standard SMTP structural validation protocol.")]
		public string Email { get; set; } = string.Empty;
	}
}
