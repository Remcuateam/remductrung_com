using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.Content
{
    [Table("Feedbacks")]
    public class Feedback : DomainEntity<int>, ISwitchable
    {
        public Feedback()
        {
        }

        public Feedback(string name, string phone, string email, string address, string message, Status status)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
            Message = message;
            Status = status;         
        }

        public Feedback(int id, string name, string phone, string email, string address, string message, Status status)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
            Message = message;
            Status = status;
        }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(64)]
        [Required]
        public string Phone { set; get; }

        [StringLength(128)]
        public string Email { set; get; }

        [StringLength(255)]
        public string Address { set; get; }

        [StringLength(255)]
        [Required]
        public string Message { set; get; }

        public Status Status { set; get; }
        public DateTime CreatedDate { set; get; }

        public DateTime? UpdatedDate { set; get; }
        public DateTime? DeletedDate { set; get; }
    }
}