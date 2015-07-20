using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities;
using WPP.Model;
using AutoMapper;

namespace WPP.Mapper
{
    public class PersonaMapper
    {
        public PersonaView GetPersona(Persona persona)
        {
            AutoMapper.Mapper.CreateMap<Persona, PersonaView>().ForMember(pv => pv.Address,p => p.Ignore()); 
            PersonaView personaMap = AutoMapper.Mapper.Map<PersonaView>(persona);
            AutoMapper.Mapper.AssertConfigurationIsValid();
            return personaMap;

        } 

        
        
    }
}
