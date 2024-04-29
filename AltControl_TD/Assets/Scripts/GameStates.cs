using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    [HideInInspector]
    public bool GameRunning = false;
    public bool IsPlayerBadAtTheVerySimpleTowerDefenseGameWeMadeAndTookAFatL = false; 
    private static GameStates _instance = new GameStates();
    private int _gregHefflyHP;
    private float _startTime;
    [SerializeField]
    public int GregHefflyBaseHP = 15;

    // Start is called before the first frame update
    void Start()
    {
        _instance.SetHP(GregHefflyBaseHP);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _instance.GameRunning = true;
            Debug.Log(_instance.GameRunning);
            _instance.SetStartTime(Time.realtimeSinceStartup);
        }

        if(_instance.GetHP() <= 0)
        {
            Debug.Log("a");
            _instance.GameRunning = false;
            Debug.Log(_instance.GameRunning);
            _instance.SetHP(GregHefflyBaseHP);
        }
    }

    public static GameStates GetInstance()
    {
        return _instance;
    }

    public void SetHP(int hp)
    {
        _gregHefflyHP = hp;
    }

    public int GetHP()
    {
        return _gregHefflyHP;
    }

    public float GetStartTime()
    {
        return _startTime;
    }

    public void SetStartTime(float time)
    {
        _startTime = time;
    }

}
