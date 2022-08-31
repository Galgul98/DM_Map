using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStats : CharacterStats
{
    [SerializeField] private int damage;
    public float attackSpeed;
    public GameObject bloodSpllater;
    [SerializeField] private bool canAttack;

    private void Start()
    {
        InitVariables();
    }

    public void DealDamage(CharacterStats statsToDamage)
    {
        //damaging function
        statsToDamage.TakeDamage(damage);
       
        
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();
        
    }
    IEnumerator bloodFeedback()
    {

        yield return new WaitForSeconds(1.0f);
        bloodSpllater.SetActive(false);
        Debug.Log("falseBlood");
    }
    public override void InitVariables()
    {
        maxHealth = 60;
        SetHealthTo(maxHealth);
        isDead = false;

        damage = 10;
        attackSpeed = 5f;
         canAttack = true;
    }
}
