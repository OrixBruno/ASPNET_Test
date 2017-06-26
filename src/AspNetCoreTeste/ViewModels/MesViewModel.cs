using System;
using System.Collections.Generic;

namespace AspNetCoreTeste.ViewModels
{
    public class MesViewModel
    {
        public PregacaoSemanaViewModel PregacaoNaSemana { get; set; }
        public List<DiaViewModel> Semana1 { get; set; } //days for week1
        public List<DiaViewModel> Semana2 { get; set; } //days for week2
        public List<DiaViewModel> Semana3 { get; set; } //days for week3
        public List<DiaViewModel> Semana4 { get; set; } //days for week4
        public List<DiaViewModel> Semana5 { get; set; } //days for week5
        public List<DiaViewModel> Semana6 { get; set; } //days for week6
        public string proxMes { get; set; }
        public string antMes { get; set; }
    }
    public class DiaViewModel
    {
        public DateTime Data { get; set; }
        public string _Data { get; set; }
        public string dateStr { get; set; }
        public int dtDia { get; set; }
        public int? diaColuna { get; set; }
    }
}