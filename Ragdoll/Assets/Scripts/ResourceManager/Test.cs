using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Test : MonoBehaviour
{
    public SOPrice soPrice;
    void Start()
    {
        DIContainer.SetModule<IDataService, DataService>();
        DIContainer.SetModule<IResourceManager, ResourceManager>();
        DIContainer.SetModule<IBoosterManager, BoosterManager>();

        //IResourceManager dataResource = DIContainer.GetModule<IResourceManager>();
        // IBoosterManager BoosterResource = DIContainer.GetModule<IBoosterManager>();
        //    List<ResourceStat> resourceData = dataResource.RESOURCE_LIST;
        //    List<BoosterStat> BoosterData = BoosterResource.Booster_LIST;
        //    //List<BoosterStat> _data = d
        //    //Debug.Log("Booster");
        //    for (int i = 0; i < BoosterData.Count; i++)
        //    {
        //        Debug.Log(JsonUtility.ToJson(BoosterData[i]));
        //        BoosterData[i].VALUE = 10;
        //        Debug.Log(BoosterData[i].ID);
        //    }
        //    //List<ResourceStat> _data = dataService.GetDataListWithType<BaseStat, ResourceStat>(dataService.GetDataSave());
        //    Debug.Log("Resource");
        //    for (int i = 0; i < resourceData.Count; i++)
        //    {
        //        Debug.Log(JsonUtility.ToJson(resourceData[i]));
        //        resourceData[i].VALUE = i;

        //        Debug.Log(resourceData[i].ID);
        //    }
        //    dataResource.SaveAllResource();
        //}
    }
}
