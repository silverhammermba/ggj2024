using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private List<FighterStats> fighterStats;

    [SerializeField]
    private GameObject battleMenu;
    void Start()
    {
        fighterStats = new List<FighterStats>();
        GameObject comedian = GameObject.FindGameObjectWithTag("Comedian");
        FighterStats currentFighterStats = comedian.GetComponent<FighterStats>();   
        currentFighterStats.CalculateNextTurn(0);

        GameObject enemy = GameObject.FindGameObjectWithTag("enemy");
        FighterStats currentEnemyStats = enemy.GetComponent<FighterStats>();
        currentFighterStats.CalculateNextTurn(0);
        fighterStats.Add(currentEnemyStats);

        fighterStats.Sort();
        this.battleMenu.SetActive(false);

        NextTurn();

    }

    // Update is called once per frame
    public void NextTurn()
    {
        FighterStats currentFighterStats = fighterStats[0];
        fighterStats.Remove(currentFighterStats);
        if (!currentFighterStats.GetDead())
        {
            GameObject currentUnit = currentFighterStats.gameObject;
            currentFighterStats.CalculateNextTurn(currentFighterStats.nextActTurn);
            fighterStats.Add(currentFighterStats);
            fighterStats.Sort();
            if(currentUnit.tag == "Comedian")
            {
                this.battleMenu.SetActive(true);
            }
            else
            {
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
