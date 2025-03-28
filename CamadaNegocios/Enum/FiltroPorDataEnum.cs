using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocios.Enum
{
    public enum FiltroPorDataEnum
    {
        Todos,
        Hoje,
        Semana,
        Mes,
        Ano
    }

    public static class FiltroPorDataEnumExtensions
    {
        public static string ObterDescricao(this FiltroPorDataEnum filtroPorDataEnum)
        {
            switch (filtroPorDataEnum)
            {
                case FiltroPorDataEnum.Todos:
                    return "Todos";
                case FiltroPorDataEnum.Hoje:
                    return "Hoje";
                case FiltroPorDataEnum.Semana:
                    return "Semana";
                case FiltroPorDataEnum.Mes:
                    return "Mês";
                case FiltroPorDataEnum.Ano:
                    return "Ano";
                default:
                    return string.Empty;
            }
        }
    }
}
