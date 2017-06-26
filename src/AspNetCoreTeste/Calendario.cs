using AspNetCoreTeste.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTeste
{
    public static class Calendario
    {
        public static Dictionary<int, string> Meses = new Dictionary<int, string>() {
            {1,"Janeiro"},
            {2,"Fevereiro"},
            {3,"Março"},
            {4,"Abril"},
            {5,"Maio"},
            {6,"Junho"},
            {7,"Julho"},
            {8,"Agosto"},
            {9,"Setembro"},
            {10,"Outubro"},
            {11,"Novembro"},
            {12,"Dezembro"}
        };

        public static Dictionary<DayOfWeek, string> DiasDaSemana = new Dictionary<DayOfWeek, string>()
        {
            {DayOfWeek.Sunday,"Domingo"},
            {DayOfWeek.Monday,"Segunda"},
            {DayOfWeek.Tuesday,"Terça"},
            {DayOfWeek.Wednesday,"Quarta"},
            {DayOfWeek.Thursday,"Quinta"},
            {DayOfWeek.Friday,"Sexta"},
            {DayOfWeek.Saturday,"Sabado"}
        };
    }
}
