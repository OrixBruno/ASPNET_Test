using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTeste.ViewModels;

namespace AspNetCoreTeste
{
    public class CalendarioConfig
    {
        public MesViewModel getCalender(int mesCorrente, int anoCorrente, PregacaoSemanaViewModel campoSemana)
        {
            MesViewModel _mes = new MesViewModel();
            _mes.Semana1 = new List<DiaViewModel>();
            _mes.Semana2 = new List<DiaViewModel>();
            _mes.Semana3 = new List<DiaViewModel>();
            _mes.Semana4 = new List<DiaViewModel>();
            _mes.Semana5 = new List<DiaViewModel>();
            _mes.Semana6 = new List<DiaViewModel>();
            _mes.PregacaoNaSemana = campoSemana;

            List<DateTime> datas = new List<DateTime>();
            datas = GetDates(anoCorrente, mesCorrente);

            foreach (DateTime dia in datas)
            {
                switch (GetWeekOfMonth(dia))
                {
                    case 1:
                        DiaViewModel dy1 = new DiaViewModel();
                        dy1.Data = dia;
                        dy1._Data = dia.ToString("d");
                        dy1.dateStr = dia.ToString("MM/dd/yyyy");
                        dy1.dtDia = dia.Day;
                        dy1.diaColuna = GetDateInfo(dy1.Data);
                        _mes.Semana1.Add(dy1);
                        break;
                    case 2:
                        DiaViewModel dy2 = new DiaViewModel();
                        dy2.Data = dia;
                        dy2._Data = dia.ToString("d");
                        dy2.dateStr = dia.ToString("MM/dd/yyyy");
                        dy2.dtDia = dia.Day;
                        dy2.diaColuna = GetDateInfo(dy2.Data);
                        _mes.Semana2.Add(dy2);
                        break;
                    case 3:
                        DiaViewModel dy3 = new DiaViewModel();
                        dy3.Data = dia;
                        dy3._Data = dia.ToString("d");
                        dy3.dateStr = dia.ToString("MM/dd/yyyy");
                        dy3.dtDia = dia.Day;
                        dy3.diaColuna = GetDateInfo(dy3.Data);
                        _mes.Semana3.Add(dy3);
                        break;
                    case 4:
                        DiaViewModel dy4 = new DiaViewModel();
                        dy4.Data = dia;
                        dy4._Data = dia.ToString("d");
                        dy4.dateStr = dia.ToString("MM/dd/yyyy");
                        dy4.dtDia = dia.Day;
                        dy4.diaColuna = GetDateInfo(dy4.Data);
                        _mes.Semana4.Add(dy4);
                        break;
                    case 5:
                        DiaViewModel dy5 = new DiaViewModel();
                        dy5.Data = dia;
                        dy5._Data = dia.ToString("d");
                        dy5.dateStr = dia.ToString("MM/dd/yyyy");
                        dy5.dtDia = dia.Day;
                        dy5.diaColuna = GetDateInfo(dy5.Data);
                        _mes.Semana5.Add(dy5);
                        break;
                    case 6:
                        DiaViewModel dy6 = new DiaViewModel();
                        dy6.Data = dia;
                        dy6._Data = dia.ToString("d");
                        dy6.dateStr = dia.ToString("MM/dd/yyyy");
                        dy6.dtDia = dia.Day;
                        dy6.diaColuna = GetDateInfo(dy6.Data);
                        _mes.Semana6.Add(dy6);
                        break;
                };
            }

            while (_mes.Semana1.Count < 7) // not starting from sunday
            {
                DiaViewModel dy = null;
                _mes.Semana1.Insert(0, dy);
            }

            if (mesCorrente == 12)
            {
                _mes.proxMes = (01).ToString() + "/" + (anoCorrente + 1).ToString();
                _mes.antMes = (mesCorrente - 1).ToString() + "/" + (anoCorrente).ToString();
            }
            else if (mesCorrente == 1)
            {
                _mes.proxMes = (mesCorrente + 1).ToString() + "/" + (anoCorrente).ToString();
                _mes.antMes = (12).ToString() + "/" + (anoCorrente - 1).ToString();
            }
            else
            {
                _mes.proxMes = (mesCorrente + 1).ToString() + "/" + (anoCorrente).ToString();
                _mes.antMes = (mesCorrente - 1).ToString() + "/" + (anoCorrente).ToString();
            }

            return _mes;
        }

        //get all dates for a month for the year specified
        public static List<DateTime> GetDates(int ano, int mes)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(ano, mes))  // Days: 1, 2 ... 31 etc.
            .Select(dia => new DateTime(ano, mes, dia)) // Map each day to a date
            .ToList();
        }

        //get number of week for the selected month by passing in a date value
        public static int GetWeekOfMonth(DateTime date)
        {
            DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);
            while (date.Date.AddDays(1).DayOfWeek != DayOfWeek.Sunday)
                date = date.AddDays(1);
            return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
        }

        //translate each day to a day number for mapping to week
        public int GetDateInfo(DateTime now)
        {
            int dayNumber = 0;
            DateTime dt = now.Date;
            string dayStr = Convert.ToString(dt.DayOfWeek);

            if (dayStr.ToLower() == "sunday")
            {
                dayNumber = 0;
            }
            else if (dayStr.ToLower() == "monday")
            {
                dayNumber = 1;
            }
            else if (dayStr.ToLower() == "tuesday")
            {
                dayNumber = 2;
            }
            else if (dayStr.ToLower() == "wednesday")
            {
                dayNumber = 3;
            }
            else if (dayStr.ToLower() == "thursday")
            {
                dayNumber = 4;
            }
            else if (dayStr.ToLower() == "friday")
            {
                dayNumber = 5;
            }
            else if (dayStr.ToLower() == "saturday")
            {
                dayNumber = 6;
            }
            return dayNumber;
        }
    }
}
