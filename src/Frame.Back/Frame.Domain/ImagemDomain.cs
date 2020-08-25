using Frame.Domain.Interfaces;
using Frame.Models;
using FrameRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Domain
{
    public class ImagemDomain : IImagemDomain
    {
        private readonly IBlobRepository _blobRepository;
        private readonly IImagemRepository _imagemRepository;

        public ImagemDomain(IBlobRepository blobRepository, IImagemRepository imagemRepository)
        {
            _blobRepository = blobRepository;
            _imagemRepository = imagemRepository;
        }

        public void CriarImagem(string imagem, string mime, string titulo, int idPost)
        {
            var uriImagem = _blobRepository.Adicionar(imagem, mime, titulo);

            _imagemRepository.CriarImagem(uriImagem, titulo, idPost);
        }

        public List<Imagem> ObterImagensPorPost(int idPost)
        {
            return _imagemRepository.ObterImagensPorPost(idPost);
        }
    }
}
