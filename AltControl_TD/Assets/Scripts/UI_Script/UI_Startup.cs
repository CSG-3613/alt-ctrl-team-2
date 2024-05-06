using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Startup : MonoBehaviour
{
    [SerializeField]
    public GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStates.GetInstance().GameRunning)
        {
            Canvas.SetActive(false);
        }
        else
        {
            Canvas.SetActive(true);
        }
    }
}
