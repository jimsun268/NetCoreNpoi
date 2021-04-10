using InfrastructureLibary.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace InfrastructureLibary.IServices
{
    public interface ILandInformationService
    {
        List<LandInformation> GetAllData();
        LandInformation GetDataById(int id);
        List<LandInformation> GetDataByName(string name);
        List<EntityEntry<LandInformation>> WriteList(List<LandInformation> landInformations);
        int SaveDataBase();

    }
}
