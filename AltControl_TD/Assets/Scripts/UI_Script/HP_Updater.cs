using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HP_Updater : MonoBehaviour
{
    
    public TMP_Text HPText;
    // Start is called before the first frame update
    void Start()
    {
        HPText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string HPToDisplay = "0";
        if(GameStates.GetInstance().GetHP() <= 0)
        {
            HPToDisplay = "0";
        }
        else
        {
            HPToDisplay = "" + GameStates.GetInstance().GetHP();
        }

        HPText.text = "HP: " + HPToDisplay;
    }
}
