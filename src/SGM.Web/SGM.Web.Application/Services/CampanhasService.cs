using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using SGM.Web.Application.Models;

namespace SGM.Web.Application.Services
{
    public class CampanhasService
    {

        public List<Campanha> FindAall()
        {
            List<Campanha> list = new List<Campanha>();
            list.Add(new Campanha{Id = new Guid(), Descricao = "Teste 1", DataFim = DateTime.Now, DataInicio = DateTime.Now});
            list.Add(new Campanha{Id = new Guid(), Descricao = "Teste 2", DataFim = DateTime.Now, DataInicio = DateTime.Now});
            
            return list;
        }
        
    }
}