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
            CampoSegunda1 = new CampoViewModel();
            CampoSegunda2 = new CampoViewModel();
            CampoTerca1 = new CampoViewModel();
            CampoTerca2 = new CampoViewModel();
            CampoQuarta1 = new CampoViewModel();
            CampoQuarta2 = new CampoViewModel();
            CampoQuinta1 = new CampoViewModel();
            CampoQuinta2 = new CampoViewModel();
            CampoSexta1 = new CampoViewModel();
            CampoSexta2 = new CampoViewModel();
            CampoSabado1 = new CampoViewModel();
            CampoSabado2 = new CampoViewModel();
            CampoSabado3 = new CampoViewModel();
            CampoDomingo = new CampoViewModel();
        }
        public ObjectId Id { get; set; }
        public string TerritorioLista { get; set; }

        [BsonElement("CampoSegunda1")]
        public CampoViewModel CampoSegunda1 { get; set; }
        [BsonElement("CampoSegunda2")]
        public CampoViewModel CampoSegunda2 { get; set; }

        [BsonElement("CampoTerca1")]
        public CampoViewModel CampoTerca1 { get; set; }
        [BsonElement("CampoTerca2")]
        public CampoViewModel CampoTerca2 { get; set; }

        [BsonElement("CampoQuarta1")]
        public CampoViewModel CampoQuarta1 { get; set; }
        [BsonElement("CampoQuarta2")]
        public CampoViewModel CampoQuarta2 { get; set; }

        [BsonElement("CampoQuinta1")]
        public CampoViewModel CampoQuinta1 { get; set; }
        [BsonElement("CampoQuinta2")]
        public CampoViewModel CampoQuinta2 { get; set; }

        [BsonElement("CampoSexta1")]
        public CampoViewModel CampoSexta1 { get; set; }
        [BsonElement("CampoSexta2")]
        public CampoViewModel CampoSexta2 { get; set; }

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
