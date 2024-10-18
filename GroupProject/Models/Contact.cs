using System.ComponentModel.DataAnnotations;

namespace GroupProject.Models
{
    public class Contact
    {
        public int ContactID { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a valid phone number")]
        public int Phone { get; set; }

        [Required(ErrorMessage = "Please enter an email.")]
        public string Email { get; set; }

        public string Organization {  get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage = "Please enter a category.")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}