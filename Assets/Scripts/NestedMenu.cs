using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public enum FightOption
{
    ThrowPie,
    ThrowShoe,
    ThrowConfetti,
    JokeInsult,
    JokePun,
    Special
}

public class NestedMenu : MonoBehaviour
{
    public GameObject menuPrefab;
    public GameObject textPrefab;
    private GameObject comedian;
    private List<Menu> menus;

    // Start is called before the first frame update
    void Start()
    {
        comedian = GameObject.FindGameObjectWithTag("Comedian");
        menus = new List<Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("down") && menus.Count > 0)
        {
            menus.Last().SelectionDown();
        }
        if (Input.GetKeyDown("up") && menus.Count > 0)
        {
            menus.Last().SelectionUp();
        }
        if (Input.GetKeyDown("left") && menus.Count > 0)
        {
            Menu last = menus[menus.Count - 1];
            menus.RemoveAt(menus.Count - 1);
            Destroy(last.gameObject);
        }
        if (Input.GetKeyDown("space"))
        {
            GameObject menuObj;
            Menu newMenu;

            if (menus.Count == 0)
            {
                menuObj = Instantiate(menuPrefab, transform);
                newMenu = menuObj.GetComponent<Menu>();

                newMenu.options = new String[] { "Throw Pie", "Joke"};
                menus.Add(newMenu);
                return;
            }

            int depth = menus.Count - 1;
            Menu last = menus[depth];
            int selection = last.Selection;

            if (depth == 0)
            {
                if (selection == 0)
                {
                    comedian.GetComponent<FighterAction>().SelectAttack("throwPie");
                }
                if (selection ==1)
                {
                   
                   comedian.GetComponent<FighterAction>().SelectAttack("joke");

                    
                }
               /* if (selection == 2)
                {
                    // TODO: special attack!
                    comedian.GetComponent<FighterAction>().SelectAttack("special");
                    return;
                }*/
               /* menuObj = Instantiate(menuPrefab, last.transform);
                RectTransform rect = menuObj.GetComponent<RectTransform>();
                rect.localPosition = last.SelectionRightEdge();

                newMenu = menuObj.GetComponent<Menu>();*/
                /*switch (selection)
                {
                    case 0:
                        newMenu.options = new string[] { "Pie", "Shoe", "Confetti" };
                        break;
                    default:
                        newMenu.options = new string[] { "Insult", "Pun", "Quip" };
                        break;
                }*/
               // menus.Add(newMenu);
                return;
            }

            if (depth == 1)
            {
                // TODO: normal attack!
                return;
            }

            Debug.LogError($"Unhandled menu selection {depth} {selection}");
        }
    }
}
