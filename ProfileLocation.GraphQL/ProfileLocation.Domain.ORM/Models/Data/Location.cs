// <auto-generated />
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileLocation.Domain.ORM.Models
{
    [Table("Location")]
    public partial class Location
    {
        public Location()
        {
            Profiles = new HashSet<Profile>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Address { get; set; }
        [StringLength(250)]
        public string ViewPort { get; set; }
        [Column("Location")]
        [StringLength(250)]
        public string Location1 { get; set; }
        public int? PlaceId { get; set; }
        public int ProfileId { get; set; }

        [InverseProperty(nameof(Profile.Location))]
        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
