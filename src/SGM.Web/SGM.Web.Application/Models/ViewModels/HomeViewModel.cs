using System.Collections.Generic;

namespace SGM.Web.Application.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<PoliticaPublica> PoliticaPublica { get; set; }
        public IEnumerable<Treinamento> Treinamento { get; set; }
    }
}