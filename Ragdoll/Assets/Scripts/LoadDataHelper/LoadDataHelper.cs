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

    public TextAsset dataGold;
    public SO_GoldShop soGoldShop;


    public TextAsset dataBooster;
    public SO_BoosterShop soBoosterShop;

    public TextAsset dataPack;
    public SO_PackShop spPackShop;
    public void LoadData()
    {
        var _dataSpin = CSVReader.Read(dataSpin);
        soSpin.LoadDataSpin(_dataSpin);

        var _dataUpgradeCharacter = CSVReader.Read(dataUpgradeCharacter);
        soUpgradeCharacter.LoadUpgradeCharacter(_dataUpgradeCharacter);

        var _DataCharacterUnlock = CSVReader.Read(DataCharacterUnlock);
        soCharacter.LoadUpgradeCharacter(_DataCharacterUnlock);

        var _dataGoldShop = CSVReader.Read(dataGold);
        soGoldShop.LoadResources(_dataGoldShop);

        var _dataBooster = CSVReader.Read(dataBooster);
        soBoosterShop.LoadBoosters(_dataBooster);

        var _dataPack = CSVReader.Read(dataPack);
        spPackShop.LoadDataPack(_dataPack);
    }

}