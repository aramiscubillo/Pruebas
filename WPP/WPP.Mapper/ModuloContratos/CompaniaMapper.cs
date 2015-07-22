using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Base;
using WPP.Model;

namespace WPP.Mapper
{
    public class CompaniaMapper
    {
        // Convierte Entidad en Modelo
        public CompaniaModel GetCompaniaModel(Compania compania)
        {
            AutoMapper.Mapper.CreateMap<Compania, CompaniaModel>();
            CompaniaModel companiaModelo = AutoMapper.Mapper.Map<CompaniaModel>(compania);
            AutoMapper.Mapper.AssertConfigurationIsValid();
            return companiaModelo;
        }

        // Convierte Modelo en Entidad
        public Compania GetCompania(CompaniaModel companiaModel)
        {
            AutoMapper.Mapper.CreateMap<CompaniaModel, Compania>();
            Compania compania = AutoMapper.Mapper.Map<Compania>(companiaModel);
            AutoMapper.Mapper.AssertConfigurationIsValid();
            return compania;
        } 
    }
}
