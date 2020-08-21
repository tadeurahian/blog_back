using Autofac;
using Autofac.Core;
using Frame.Domain;
using Frame.Domain.Interfaces;
using Frame.Orq;
using Frame.Orq.Interfaces;
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
            builder.RegisterType<PostOrq>().As<IPostOrq>();

            builder.RegisterType<UsuarioDomain>().As<IUsuarioDomain>();
            builder.RegisterType<PostDomain>().As<IPostDomain>();
            builder.RegisterType<TextoDomain>().As<ITextoDomain>();
            builder.RegisterType<ImagemDomain>().As<IImagemDomain>();
            builder.RegisterType<JwtDomain>().As<IJwtDomain>();

            builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>();
            builder.RegisterType<PostRepository>().As<IPostRepository>();
            builder.RegisterType<TextoRepository>().As<ITextoRepository>();
            builder.RegisterType<BlobRepository>().As<IBlobRepository>();
            builder.RegisterType<ImagemRepository>().As<IImagemRepository>();
        }
    }
}
