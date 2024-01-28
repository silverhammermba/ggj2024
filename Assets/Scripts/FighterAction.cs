using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class FighterAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject clown1;

    [SerializeField]
    private GameObject jokePrefab;

    [SerializeField]
    private GameObject throwPrefab;

    [SerializeField]
    private Sprite faceIcon;

    private GameObject currentAttack;
    private GameObject jokeAttack;
    private GameObject throwAttack;

    public void SelectAttack(string btn)
    {
        GameObject victim = clown1;
        if (tag == "clown1")
        {
            victim = enemy;
        }
        if (btn.CompareTo("joke") == 0)
        {
            jokeAttack.GetComponent<AttackScript>.Attack(victim);

        }
        else if (btn.CompareTo("throwPie") == 0)
        {
            throwAttack.GetComponent<AttackScript>.Attack(victim);

        }
        else
        {
            Debug.Log("Special!");
        }


    }
}
