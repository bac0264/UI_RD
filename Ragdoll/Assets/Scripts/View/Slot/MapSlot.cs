using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapSlot : _ActionSlotSetup<MapSlot, MapDataStat>
{
    IMapManager mapManager;
    public Transform StarContainer;
    public Image[] stars;

    public override MapDataStat DATA
    {
        get => base.DATA;
        set
        {
            base.DATA = value;
            if (TXT_VALUE != null)
            {
                if (DATA.IS_OPEN)
                {
                    TXT_VALUE.color = new Color(1, 1, 1, 1);
                }
                else TXT_VALUE.color = new Color(1, 1, 1, 120f / 255);
                TXT_VALUE.text = (DATA.ID + 1).ToString();
            }
            if (IMG_BG != null)
            {
                IMG_BG.sprite = SpriteDB.Instance.GetBackgroundInMap(DATA.IS_OPEN);
            }
            if(stars.Length > 0)
            {
                int i = 0;
                for (; i < stars.Length && i < DATA.STAR; i++)
                {
                    stars[i].sprite = SpriteDB.Instance.GetKey(i, DATA.STAR);
                }
                for(; i < stars.Length; i++)
                {
                    stars[i].sprite = SpriteDB.Instance.GetKey(i, DATA.STAR);
                }
            }
        }
    }
    public void SetupMapManager(IMapManager mapManager)
    {
        this.mapManager = mapManager;
    }
    public bool PickLevel()
    {
        if(DATA != null && DATA.IS_OPEN)
        {
            DATA.STAR = Random.Range(1, 4);
            DATA = DATA;
            mapManager.SetupNextLevel(DATA);
            if (MapEnhance.instance != null) MapEnhance.instance.masterScroller.ReloadData();
            if (mapManager != null)
            {
               // mapManager.CUR_MAP = DATA;
              //  mapManager.SaveMaps();
            }
            else
            {
                //DIContainer.GetModule<IMapManager>().CUR_MAP = DATA;
               // DIContainer.GetModule<IMapManager>().SaveMaps();
            }
            return true;
        }
        return false;
    }
    private void OnValidate()
    {
        if (stars.Length == 0) stars = StarContainer.GetComponentsInChildren<Image>();
    }
    public void SetData(MapDataStat data)
    {
        DATA = data;
    }
}
