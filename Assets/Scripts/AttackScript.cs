using System.Buffers;
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
    //min and max are the range of damage that an atttack could be
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
    private float xMagicNewScale;

    //potential audience Enjoyment bar
    private Vector2 magicScale;

    private void Start()
    {
        magicScale = GameObject.Find("SpecialMagicFill").GetComponent<RectTransform>().localScale;
    }

    public void Attack(GameObject victim)
    {
        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = victim.GetComponent<FighterStats>();
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
                attackerStats.magic = attackerStats.magic - magicCost;
            }
            float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
            damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));
            owner.GetComponent<Animator>().Play(animationName);
            targetStats.RecieveDamage(damage);
        }
    }
}