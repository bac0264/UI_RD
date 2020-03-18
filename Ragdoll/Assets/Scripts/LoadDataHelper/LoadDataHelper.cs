using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataHelper : MonoBehaviour
{
    public TextAsset dataSpin;
    public SO_Spin soSpin;

    public TextAsset dataUpgradeCharacter;
    public SO_UpgradeCharacter soUpgradeCharacter;

    public TextAsset DataCharacterUnlock;
    public SO_CharacterUnlock soCharacter;
    public void LoadData()
    {
        var _dataSpin = CSVReader.Read(dataSpin);
        soSpin.LoadDataSpin(_dataSpin);

        var _dataUpgradeCharacter = CSVReader.Read(dataUpgradeCharacter);
        soUpgradeCharacter.LoadUpgradeCharacter(_dataUpgradeCharacter);

        var _DataCharacterUnlock = CSVReader.Read(DataCharacterUnlock);
        soCharacter.LoadUpgradeCharacter(_DataCharacterUnlock);
    }

}