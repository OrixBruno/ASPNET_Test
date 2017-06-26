using AspNetCoreTeste.ViewModels;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTeste.IServices
{
    public interface IPregacaoService
    {
        Task<List<PregacaoSemanaViewModel>> GetLista();
        Task<PregacaoSemanaViewModel> Create(PregacaoSemanaViewModel p);
        Task<PregacaoSemanaViewModel> Get(ObjectId id);
        Task Update(ObjectId id, PregacaoSemanaViewModel p);
        Task Remove(ObjectId id);
        Task<List<DateTime>> GetListaPorData();
        Task<PregacaoSemanaViewModel> GetPorData(DateTime date);
    }
}
