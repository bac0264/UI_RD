using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(LoadDataHelper))]
[CanEditMultipleObjects]
public class LoadDataHelperEditor : Editor
{

    public override void OnInspectorGUI()
    {
        LoadDataHelper myscript = (LoadDataHelper)target;

        if (GUILayout.Button("Load Data"))
        {
            myscript.LoadData();
            EditorUtility.SetDirty(myscript.dataSpin);
            myscript.LoadData();
            EditorUtility.SetDirty(myscript.dataUpgradeCharacter);
            myscript.LoadData();
            EditorUtility.SetDirty(myscript.DataCharacterUnlock);
            myscript.LoadData();
            EditorUtility.SetDirty(myscript.dataGold);
            myscript.LoadData();
            EditorUtility.SetDirty(myscript.dataBooster);
            myscript.LoadData();
            EditorUtility.SetDirty(myscript.dataPack);
            myscript.LoadData();
        }

        base.OnInspectorGUI();
    }

}
#endif