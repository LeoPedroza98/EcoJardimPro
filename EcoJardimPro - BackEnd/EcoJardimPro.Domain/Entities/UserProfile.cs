using EcoJardimPro.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcoJardimPro.Domain.Entities
{
    [Table("UserProfile")]
    public class UserProfile : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] public long Id { get; set; }
        [MaxLength(60)] public string Name { get; set; }
        [MaxLength(255)] public string Role { get; set; }

        [NotMapped] public static UserProfile Master => new UserProfile(1, "Master", "Master");

        public UserProfile(long id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
        }

        public static UserProfile[] ObterDados()
        {
            return new UserProfile[]
            {
                Master
            };
        }
    }

}
