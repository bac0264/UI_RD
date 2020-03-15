using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IDataService
{
    DataSave<T> GetDataSaveWithType<T>();
    void Save();
    void Load();
    List<T1> GetDataListWithType<T, T1>(DataSave<T> data);
}
