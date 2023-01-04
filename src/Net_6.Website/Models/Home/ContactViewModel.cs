using System.ComponentModel.DataAnnotations;

namespace Net_6.Website.Models
{
    public class ContactViewModel
    {
        public string Name { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress, ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? ErrorMessage { get; set; }
    }
}
