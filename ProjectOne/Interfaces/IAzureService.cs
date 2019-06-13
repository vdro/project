using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectOne.Models;

namespace ProjectOne.Interfaces
{
    public interface IAzureService
    {
        Task<bool> TriggerLogicApp(AzureModel model);
    }
}
