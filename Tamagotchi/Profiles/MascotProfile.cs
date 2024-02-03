using AutoMapper;
using Tamagotchi.Entites;
using Tamagotchi.Models;

namespace Tamagotchi.Profiles;

public class MascotProfile : Profile
{
    public MascotProfile()
    {
        CreateMap<Pokemon, Mascot>()
            .ForMember(m =>
                m.Types, options =>
                    options.MapFrom(p =>
                        p.Types.Select(t => t.Type.Name.ToUpper())))
            .ForMember(m =>
                m.Abilities, options =>
                    options.MapFrom(p =>
                        p.Abilities.Select(a => a.Ability.Name.ToUpper())));
    }
}
