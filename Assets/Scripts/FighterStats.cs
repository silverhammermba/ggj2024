using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStats : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    //how much health you have left
    [SerializeField]
    private GameObject healthFill;
    [SerializeField]
    private GameObject magicFill;

    [Header("Stats")]
    public float health;
    public float magic;
    public float attack;
    public float defense;
    public float range;
    public float speed;
    public float experience;
   

    private float startHealth;
    private float startMagic;

    [HideInInspector]
    public int nextActTurn;

    private bool dead = false;

    //resize heatlh bar and magic
    private Transform healthTransform;
    private Transform magicTransform;

    private Vector2 healthScale;
    private Vector2 magicScale;

    private float xNewHealthScale;
    private float xNewMagicScale;

    private void Start()
    {
        healthTransform = healthFill.GetComponent<RectTransform>();
        healthScale = healthTransform.localScale;

        magicTransform = magicFill.GetComponent<RectTransform>();t
        magicScale = magicTransform.localScale;

        startHealth = health;
        startMagic = magic;

    }

    public void RecieveDamage(float damage)
    {
        health = health - damage;
        //plays damage animation
        animator.Play("Damage");

        // Set damage text
        if(health <= 0)
        {
            dead = true;
            gameObject.tag = "Dead";
            Destroy(healthFill);
            Destroy(gameObject);
        }else
        {
            //changes how much health is in the bar based on attack
            xNewHealthScale = healthScale.x * (health / startHealth);
            healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);
        }
       
    }


    public void updateMagicFill(float cost)
    {
        magic = magic - cost;
        xNewMagicScale = magicScale.x * (magic / startMagic);
        magicFill.transform.localScale = new Vector2(xNewMagicScale, magicScale.y);
    }
}