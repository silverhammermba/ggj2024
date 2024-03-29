using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public GameObject owner;

    [SerializeField]
    private string animationName;

    [SerializeField]
    private bool magicAttack;

    [SerializeField]
    private float magicCost;

    [SerializeField]
    private float minAttackMultiplier;

    [SerializeField]
    private float maxAttackMultiplier;

    [SerializeField]
    private float minDefenseMultiplier;

    [SerializeField]
    private float maxDefenseMultiplier;

    private FighterStats attackerStats;
    private FighterStats targetStats;
    private float damage = 0.0f;

    //potential audience Enjoyment bar
    private Vector2 magicScale;

    private void Start()
    {
        //magicScale = GameObject.Find("SpecialMagicFill").GetComponent<RectTransform>().localScale;
    }

    public void Attack(GameObject victim)
    {
        Debug.Log("warning", owner);
        Debug.Log("warning", victim);
        if (owner == null) { Debug.Log("owner missing"); }
        attackerStats = owner.GetComponent<FighterStats>();
        if (attackerStats == null) { Debug.Log("Owner stats missing"); }

        if (victim == null) { Debug.Log("victim missing"); }
        targetStats = victim.GetComponent<FighterStats>();
        if (targetStats == null) { Debug.Log("targetStats"); }
       
       
        if (attackerStats.magic >= magicCost)
        {
            float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);
            if(magicCost > 0)
            {
                attackerStats.updateMagicFill(magicCost);
            }
            

            damage = multiplier * attackerStats.melee;
            if (magicAttack)
            {
                damage = multiplier * attackerStats.throwRange;
            }

            float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
            damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));
            owner.GetComponent<Animator>().Play(animationName);
            targetStats.ReceiveDamage(Mathf.CeilToInt(damage));
            attackerStats.updateMagicFill(magicCost);
        }
        else
        {
            Invoke("SkipTurnContinueGame", 2);
        }
    }

    void SkipTurnContinueGame()
    {
        GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
    }
}
