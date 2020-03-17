using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class InitDI : MonoBehaviour
{
    private void Awake()
    {
        DIContainer.SetModule<IDataService, DataService>();
        DIContainer.SetModule<IResourceManager, ResourceManager>();
        DIContainer.SetModule<IBoosterManager, BoosterManager>();
    }
}
