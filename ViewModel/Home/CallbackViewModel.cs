using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplicationProperty.Models;

namespace WebApplicationProperty.ViewModel
{
    public class CallbackViewModel
    {
        /// <summary>
        /// Номер обращения.
        /// </summary>
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Name", Prompt = "Name (Required)")]
        public string Name { get; set; }

        [Phone]
        [Required]
        [MaxLength(100)]
        [Display(Name = "Phone", Prompt = "Phone (Required)")]
        public string Phone { get; set; }

        [EmailAddress]
        [MaxLength(256)]
        [Display(Name = "Email", Prompt = "Email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(2000)]
        [Display(Name = "Message", Prompt = "Message")]
        public string Message { get; set; }

        public int PropertyId { get; set; }
        public string PropertyName { get; set; }

        public CallbackViewModel() { }
        public CallbackViewModel(CallbackModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Phone = model.Phone;
            Email = model.Email;
            Message = model.Message;
            PropertyId = model.PropertyId;
            PropertyName = model.Property?.Name ?? string.Empty;
        }
    }
}
