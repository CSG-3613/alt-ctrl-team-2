using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I am touching things");
    }
}
