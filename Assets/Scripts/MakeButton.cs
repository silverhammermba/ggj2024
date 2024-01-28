using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    [SerializeField]
    private bool physical;
    private GameObject clown;
    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        clown = GameObject.FindGameObjectWithTag("Comedian");
    }

    private void AttachCallback(string btn)
    {
        if(btn.CompareTo("joke") == 0)
        {
            clown.GetComponent<FighterAction>().SelectAttack("joke");

        }else if (btn.CompareTo("throwPie") == 0)
        {
            clown.GetComponent<FighterAction>().SelectAttack("throwPie");
        }
        else
        {
            clown.GetComponent<FighterAction>().SelectAttack("special");
        }
    }

}
