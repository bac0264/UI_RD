using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IResourceManager
{
    ResourceStat[] GetResourceList();
    ResourceStat GetResourceWithID(int id);

    void LoadResources();

    void SaveResources();
}
