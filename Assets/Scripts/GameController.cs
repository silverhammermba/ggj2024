using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Transactions;
using UnityEngine.SocialPlatforms;

public class GameController : MonoBehaviour
{
    private List<FighterStats> fighterStats;

    private GameObject battleMenu;

    public Text battleText;

    private void Awake()
    {
        battleMenu = GameObject.Find("actionMenu");
    }
    void Start()
    {
        fighterStats = new List<FighterStats>();
        GameObject hero = GameObject.FindGameObjectWithTag("Comedian");
        FighterStats currentFighterStats = hero.GetComponent<FighterStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentFighterStats);

        GameObject enemy = GameObject.FindGameObjectWithTag("enemy");
        FighterStats currentEnemyStats = enemy.GetComponent<FighterStats>();
        currentEnemyStats.CalculateNextTurn(0);
        fighterStats.Add(currentEnemyStats);

        fighterStats.Sort();


        NextTurn();
    }

    public void NextTurn()
    {
        battleText.gameObject.SetActive(false);
        FighterStats currentFighterStats = fighterStats[0];
        fighterStats.Remove(currentFighterStats);
        if (!currentFighterStats.GetDead())
        {
            GameObject currentUnit = currentFighterStats.gameObject;
            currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
            fighterStats.Add(currentFighterStats);
            fighterStats.Sort();
            if (currentUnit.tag == "Comedian")
            {
                this.battleMenu.SetActive(true);
            }
            else
            {
                this.battleMenu.SetActive(false);
                string attackType = Random.Range(0, 2) == 1 ? "melee" : "range";
                currentUnit.GetComponent<FighterAction>().SelectAttack(attackType);
            }
        }
        else
        {
            NextTurn();
        }
    }
}
