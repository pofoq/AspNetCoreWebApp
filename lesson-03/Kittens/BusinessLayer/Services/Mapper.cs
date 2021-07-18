using System.Linq;
using BusinessLayer.Abstraction.Dto;
using DataLayer.Abstraction.Entities;

namespace BusinessLayer.Services
{
    public static class Mapper
    {
        internal static Kitten MapKitten(KittenDto kitten)
        {
            if (kitten is null)
            {
                return null;
            }
            return new Kitten
            {
                Color = kitten.Color,
                Feed = kitten.Feed,
                HasCirtificate = kitten.HasCirtificate,
                Id = kitten.Id,
                NickName = kitten.NickName,
                Weight = kitten.Weight,
                Clinics = kitten.Clinics?.Select(c => MapClinic(c)).ToList()
            };
        }

        internal static KittenDto MapKitten(Kitten kitten)
        {
            if (kitten is null)
            {
                return null;
            }
            return new KittenDto
            {
                Color = kitten.Color,
                Feed = kitten.Feed,
                HasCirtificate = kitten.HasCirtificate,
                Id = kitten.Id,
                NickName = kitten.NickName,
                Weight = kitten.Weight,
                Clinics = kitten.Clinics?.Select(c => MapClinic(c)).ToList()
            };
        }

        internal static Clinic MapClinic(ClinicDto clinic)
        {
            if (clinic is null)
            {
                return null;
            }
            return new Clinic
            {
                Id = clinic.Id,
                Name = clinic.Name
            };
        }

        internal static ClinicDto MapClinic(Clinic clinic)
        {
            if (clinic is null)
            {
                return null;
            }
            return new ClinicDto
            {
                Id = clinic.Id,
                Name = clinic.Name
            };
        }
    }
}
