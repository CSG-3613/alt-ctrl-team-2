using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float time = 0.0f;
    public TextMeshProUGUI text;
    private int timeTemp;
    private bool gameStart = false;
    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            time += Time.deltaTime;
            timeTemp = (int)time;
            text.text = "Time: " + timeTemp.ToString();
        }
        
    }
}
