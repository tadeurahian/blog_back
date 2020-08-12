using Autofac;
using Autofac.Core;
using Frame.Domain;
using Frame.Domain.Interfaces;
using Frame.Orq;
using FrameRepository;
using FrameRepository.Interfaces;
using System;

namespace Frame.Cross
{
    public static class IoCConfig
    {
        public static ContainerBuilder Container;

        public static void Inicializar(ContainerBuilder builder)
        {
            Container = builder;

            builder.RegisterType<UsuarioOrq>().As<IUsuarioOrq>();
            builder.RegisterType<UsuarioDomain>().As<IUsuarioDomain>();
            builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>();
        }
    }
}
