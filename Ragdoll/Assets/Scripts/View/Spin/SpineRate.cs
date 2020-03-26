using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineRate : MonoBehaviour
{
    public Transform pos_1;
    public Transform pos_2;

    public void Awake()
    {
        float aspect = (float)Screen.height / (float)Screen.width; // Portrait
        if(aspect >= 2.3) // 21:9
        {
            pos_1.localPosition = new Vector2(0, -1392);
            pos_1.localScale = new Vector2(108, 108);
            pos_2.localPosition = new Vector2(0, -323);
            pos_2.localScale = new Vector2(115, 115);
        }
        else if (aspect >= 2) // 18:9
        {
            pos_1.localPosition = new Vector2(0, -1242);
            pos_1.localScale = new Vector2(108, 108);
            pos_2.localPosition = new Vector2(0, -286);
            pos_2.localScale = new Vector2(108, 108);
        }
        else if (aspect >= 1.74)  // 16:9
        {
            pos_1.localPosition = new Vector2(0, -1051);
            pos_1.localScale = new Vector2(99, 99);
            pos_2.localPosition = new Vector2(0, -244);
            pos_2.localScale = new Vector2(99, 99);
        }
        else if (aspect >= 1.6)// 3:5
        {
            pos_1.localPosition = new Vector2(0, -1019);
            pos_1.localScale = new Vector2(90, 90);
            pos_2.localPosition = new Vector2(0, -294);
            pos_2.localScale = new Vector2(110, 110);
        }
        else
        { // 4:3 3:2
            pos_1.localPosition = new Vector2(0, -818);
            pos_1.localScale = new Vector2(70, 70);
            pos_2.localPosition = new Vector2(0, -236);
            pos_2.localScale = new Vector2(100, 100);
        }
    }
}
