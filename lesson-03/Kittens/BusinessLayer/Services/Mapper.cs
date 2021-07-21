using System.Linq;
using BusinessLayer.Extensions;
using BusinessLayer.Abstraction.Dto;
using DataLayer.Abstraction.Entities;

namespace BusinessLayer.Services
{
    public static class Mapper
    {
        internal static Kitten Map(KittenDto kitten)
        {
            kitten.EnsureNotNull(nameof(kitten));
            return new Kitten
            {
                Color = kitten.Color,
                Feed = kitten.Feed,
                HasCirtificate = kitten.HasCirtificate,
                Id = kitten.Id,
                NickName = kitten.NickName,
                Weight = kitten.Weight,
                Clinics = kitten.Clinics?.Select(c => Map(c)).ToList()
            };
        }

        internal static KittenDto Map(Kitten kitten)
        {
            kitten.EnsureNotNull(nameof(kitten));
            return new KittenDto
            {
                Color = kitten.Color,
                Feed = kitten.Feed,
                HasCirtificate = kitten.HasCirtificate,
                Id = kitten.Id,
                NickName = kitten.NickName,
                Weight = kitten.Weight,
                Clinics = kitten.Clinics?.Select(c => Map(c)).ToList()
            };
        }

        internal static Clinic Map(ClinicDto clinic)
        {
            clinic.EnsureNotNull(nameof(clinic));
            return new Clinic
            {
                Id = clinic.Id,
                Name = clinic.Name
            };
        }

        internal static ClinicDto Map(Clinic clinic)
        {
            clinic.EnsureNotNull(nameof(clinic));
            return new ClinicDto
            {
                Id = clinic.Id,
                Name = clinic.Name
            };
        }

        internal static UserDto Map(User user)
        {
            user.EnsureNotNull(nameof(user));

            return new UserDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                RefreshToken = new RefreshToken()
                {
                    Token = user.RefreshToken,
                    Expires = user.Expires
                }
            };
        }

        internal static User Map(UserDto user)
        {
            user.EnsureNotNull(nameof(user));

            return new User()
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                RefreshToken = user.RefreshToken.Token,
                Expires = user.RefreshToken.Expires
            };
        }
    }
}
