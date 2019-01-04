using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Infrastructure.Enums;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.Entities.Content
{
    [Table("Contacts")]
    public class Contact : DomainEntity<string>, ISwitchable
    {        

        public Contact()
        {
        }

        public Contact(string name, string phone, string email, string address, string website, string other, double? lat, double? lng, Status status)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
            Website = website;
            Other = other;
            Lat = lat;
            Lng = lng;
            Status = status;
        }

        public Contact(string id, string name, string phone, string email, string website, string address, string other, double? lng, double? lat, Status status)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Website = website;
            Address = address;
            Other = other;
            Lng = lng;
            Lat = lat;
            Status = status;
        }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(64)]
        [Required]
        public string Phone { set; get; }

        [StringLength(128)]
        [Required]
        public string Email { set; get; }

        [StringLength(255)]
        [Required]
        public string Address { set; get; }

        [StringLength(128)]
        public string Website { set; get; }

        [StringLength(255)]
        public string Other { set; get; }

        public double? Lat { set; get; }
        public double? Lng { set; get; }
        public Status Status { set; get; }
    }
}