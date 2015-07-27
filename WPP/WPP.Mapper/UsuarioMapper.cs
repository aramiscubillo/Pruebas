using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPP.Entities.Objects.Generales;
using WPP.Model;


namespace WPP.Mapper
{
    public class UsuarioMapper
    {
        // Convierte Entidad en Modelo
        public UsuarioModel GetUsuarioModel(Usuario usuario)
        {
            AutoMapper.Mapper.CreateMap<Usuario, UsuarioModel>();
            UsuarioModel usuarioModelo = AutoMapper.Mapper.Map<UsuarioModel>(usuario);
            return usuarioModelo;
        }

        // Convierte Modelo en Entidad
        public Usuario GetUsuario(UsuarioModel usuarioModelo)
        {
            AutoMapper.Mapper.CreateMap<UsuarioModel, Usuario>();
            Usuario usuario = AutoMapper.Mapper.Map<Usuario>(usuarioModelo);
            return usuario;
        }
    }
}
