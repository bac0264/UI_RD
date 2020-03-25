using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IDataService
{
    UserStat GetUserInfo();
    DataSave<T> GetDataSaveWithType<T>();
    void Save<T>();
    void Load();
   // List<T1> GetDataListWithType<T, T1>(DataSave<T> data);
}
