using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionScript : MonoBehaviour
{
    public TMP_Text currentStateText;

    void Start()
    {
        currentStateText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if ((Input.GetKeyDown("1")))
        {
            currentStateText.text = "Tower A";
        }
        if ((Input.GetKeyDown("2")))
        {
            currentStateText.text = "Tower B";
        }
        if ((Input.GetKeyDown("3")))
        {
            currentStateText.text = "Tower C";
        }
        if ((Input.GetKeyDown("4")))
        {
            currentStateText.text = "Remove";
        }
    }
}
