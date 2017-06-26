using AspNetCoreTeste.IServices;
using AspNetCoreTeste.ViewModels;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTeste.Services
{
    public class PregacaoService : DataAccess<PregacaoSemanaViewModel, ObjectId>, IPregacaoService
    {
        public PregacaoService() : base("Semana")
        {
            //Collection = CampoSemana
        }
        public override async Task<PregacaoSemanaViewModel> Get(ObjectId id)
        {
            var filter = Builders<PregacaoSemanaViewModel>.Filter.Eq(n => n.Id, id);
            var objeto = await _db.GetCollection<PregacaoSemanaViewModel>(_collection).FindAsync(filter);
            return objeto.FirstOrDefault();
        }

        public override async Task Update(ObjectId id, PregacaoSemanaViewModel p)
        {
            p.Id = id;
            var filter = Builders<PregacaoSemanaViewModel>.Filter.Eq(n => n.Id, id);
            await _db.GetCollection<PregacaoSemanaViewModel>(_collection).ReplaceOneAsync(filter, p);
        }
        public override async Task Remove(ObjectId id)
        {
            var filter = Builders<PregacaoSemanaViewModel>.Filter.Eq(n => n.Id, id);
            var operation = await _db.GetCollection<PregacaoSemanaViewModel>(_collection).DeleteOneAsync(filter);
        }

        public async Task<List<DateTime>> GetListaPorData()
        {
            return await _db.GetCollection<PregacaoSemanaViewModel>(_collection)
                .Find(Builders<PregacaoSemanaViewModel>.Filter.Empty)
                .Project(new ProjectionDefinitionBuilder<PregacaoSemanaViewModel>().Expression(x => x.CampoTercaItaim.Dia))
                .ToListAsync();
        }
        public async Task<PregacaoSemanaViewModel> GetPorData(DateTime date)
        {
            try
            {
                var filter = Builders<PregacaoSemanaViewModel>.Filter.Eq(n => n.CampoTercaItaim.Dia, date);
                var objeto = await _db.GetCollection<PregacaoSemanaViewModel>(_collection).FindAsync(filter);
                return objeto.ToList().LastOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}