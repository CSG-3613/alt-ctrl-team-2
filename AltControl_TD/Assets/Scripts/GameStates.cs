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
    [SerializeField]
    public GameObject TheSpawner;
    public int GregHefflyBaseHP = 15;
    

    // Start is called before the first frame update
    void Start()
    {
        _instance.SetHP(GregHefflyBaseHP);
        _instance.SetSpawner(TheSpawner);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _instance.GameRunning = true;
            //Debug.Log("is the game running:" + _instance.GameRunning);
            _instance.SetHP(GregHefflyBaseHP);
            _instance.GetSpawner().GetComponent<EnemySpawner>().Reset();
        }

        if(_instance.GameRunning && _instance.GetHP() <= 0)
        {
            //Debug.Log("a");
            _instance.GameRunning = false;
            //Debug.Log(_instance.GameRunning);
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

    

    public void SetSpawner(GameObject theSpawner){
        TheSpawner = theSpawner;
    }

    public GameObject GetSpawner(){
        return TheSpawner;
    }

}
