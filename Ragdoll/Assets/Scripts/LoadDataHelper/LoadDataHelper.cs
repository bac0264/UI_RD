using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataHelper : MonoBehaviour
{
    public TextAsset dataSpin;
    public SO_Spin soSpin;
    public void LoadData()
    {
        var _dataSpin = CSVReader.Read(dataSpin);
        soSpin.LoadDataSpin(_dataSpin);   
    }

}