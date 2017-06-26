using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTeste.ViewModels
{
    public class PregacaoSemanaViewModel
    {
        public PregacaoSemanaViewModel()
        {
            CampoSegundaItaim = new CampoViewModel();
            CampoSegundaFerraz = new CampoViewModel();
            CampoTercaItaim = new CampoViewModel();
            CampoTercaFerraz = new CampoViewModel();
            CampoQuartaItaim = new CampoViewModel();
            CampoQuartaFerraz = new CampoViewModel();
            CampoQuintaItaim = new CampoViewModel();
            CampoQuintaFerraz = new CampoViewModel();
            CampoSextaItaim = new CampoViewModel();
            CampoSextaFerraz = new CampoViewModel();
            CampoSabado1 = new CampoViewModel();
            CampoSabado2 = new CampoViewModel();
            CampoSabado3 = new CampoViewModel();
            CampoDomingo = new CampoViewModel();
        }
        public ObjectId Id { get; set; }

        [BsonElement("CampoSegundaItaim")]
        public CampoViewModel CampoSegundaItaim { get; set; }
        [BsonElement("CampoSegundaFerraz")]
        public CampoViewModel CampoSegundaFerraz { get; set; }

        [BsonElement("CampoTercaItaim")]
        public CampoViewModel CampoTercaItaim { get; set; }
        [BsonElement("CampoTercaFerraz")]
        public CampoViewModel CampoTercaFerraz { get; set; }

        [BsonElement("CampoQuartaItaim")]
        public CampoViewModel CampoQuartaItaim { get; set; }
        [BsonElement("CampoQuartaFerraz")]
        public CampoViewModel CampoQuartaFerraz { get; set; }

        [BsonElement("CampoQuintaItaim")]
        public CampoViewModel CampoQuintaItaim { get; set; }
        [BsonElement("CampoQuintaFerraz")]
        public CampoViewModel CampoQuintaFerraz { get; set; }

        [BsonElement("CampoSextaItaim")]
        public CampoViewModel CampoSextaItaim { get; set; }
        [BsonElement("CampoSextaFerraz")]
        public CampoViewModel CampoSextaFerraz { get; set; }

        [BsonElement("CampoSabado1")]
        public CampoViewModel CampoSabado1 { get; set; }
        [BsonElement("CampoSabado2")]
        public CampoViewModel CampoSabado2 { get; set; }
        [BsonElement("CampoSabado3")]
        public CampoViewModel CampoSabado3 { get; set; }

        [BsonElement("CampoDomingo")]
        public CampoViewModel CampoDomingo { get; set; }
    }
}
