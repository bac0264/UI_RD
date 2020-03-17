using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IBoosterManager
{
    BoosterStat[] GetBoosterList();
    BoosterStat GetBoosterWithID(int id);

    void LoadBoosters();
    void SaveBoosters();
}