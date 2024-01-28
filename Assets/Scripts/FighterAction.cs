using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class FighterAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject comedian;

    [SerializeField]
    private GameObject meleePrefab;

    [SerializeField]
    private GameObject rangePrefab;

    [SerializeField]
    private Sprite faceIcon;

    private GameObject currentAttack;
    

    private void Start()
    {
        comedian = GameObject.FindGameObjectWithTag("Comedian");
        enemy = GameObject.FindGameObjectWithTag("enemy");
    }
    public void SelectAttack(string btn)
    {
        GameObject victim = comedian;
        if (tag == "Comedian")
        {
            victim = enemy;
        }
        if (btn.CompareTo("joke") == 0)
        {
            meleePrefab.GetComponent<AttackScript>().Attack(victim);

        }
        else if (btn.CompareTo("throwPie") == 0)
        {
            rangePrefab.GetComponent<AttackScript>().Attack(victim);

        }
        else
        {
            Debug.Log("Special!");
        }


    }
}
