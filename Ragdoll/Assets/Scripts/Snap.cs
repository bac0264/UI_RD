using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Snap : MonoBehaviour
{
    // process
    public RectTransform panel; // to hold the scrollView
    public List<RectTransform> posList; // 
    public RectTransform center; // Center to compare the distance for each iten 
    public bool startSnap;
    public float[] distance; // All Item's center
    private bool dragging = false;
    public float bttnDistance;
    public int minButtonNum;
    public bool checkStart;
    private const int MaxDistance = 2;
    private ICharacterManager characterManager;
    private CharacterSlotPanel container;
    // UI
    public void SetupSnap(CharacterStat cur, CharacterSlotPanel panel, ICharacterManager characterManager)
    {
        checkStart = true;
        container = panel;
        minButtonNum = cur.ID;
        distance = new float[posList.Count];
        _initPos((minButtonNum) * (-bttnDistance));
        this.characterManager = characterManager;

    }
    private void OnValidate()
    {
        if (posList == null || posList.Count == 0 /*|| slots == null*/)
        {
            CharacterSlot[] slots = GetComponentsInChildren<CharacterSlot>();
            foreach (CharacterSlot slot in slots)
            {
                posList.Add(slot.GetComponent<RectTransform>());
            }
        }    
    }
    private void Update()
    {
        if (checkStart)
        {
            for (int i = 0; i < posList.Count; i++)
            {
                distance[i] = (float)Mathf.Abs(center.transform.position.x - posList[i].transform.position.x);
                float x = Mathf.Abs(distance[i] - MaxDistance) / MaxDistance;
                Vector3 scale = new Vector3(x, x, 0);
                posList[i].transform.DOScale(scale, 0f);
            }
            float minDistance = Mathf.Min(distance);

            for (int a = 0; a < posList.Count; a++)
            {
                if (minDistance == distance[a])
                {
                    minButtonNum = a;
                    if (container != null) container.RefeshUI(minButtonNum);
                    break;
                }
            }
            if (!dragging)
            {
                LerpToImage(minButtonNum * (-bttnDistance));
            }
        }
    }
    public void LerpToImage(float position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, 0.2f);
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);
        panel.anchoredPosition = newPosition;
    }
    public void _initPos(float position)
    {
        float newX = position;
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);
        panel.anchoredPosition = newPosition;
        checkStart = true;
    }
    public void StartDrag()
    {
        dragging = true;
    }
    public void EndDrag()
    {
        dragging = false;
    }
    public int getMinButtonNum()
    {
        return minButtonNum;
    }
    public bool getDrag()
    {
        return dragging;
    }
}