using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    
    public bool GameRunning = false;
    public bool IsPlayerBadAtTheVerySimpleTowerDefenseGameWeMadeAndTookAFatL = false; 
    private static GameStates _instance = new GameStates();
    [SerializeField]
    public int GregHefflyHP = 15;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _instance.GameRunning = true;
            Debug.Log(_instance.GameRunning);
        }
    }

    public static GameStates GetInstance()
    {
        return _instance;
    }
   
}
