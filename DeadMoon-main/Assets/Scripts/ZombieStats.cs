using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStats : CharacterStats
{

    public float damage;

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

    public override void TakeDamage(float damage)
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
        
        SetHealthTo(maxHealth);
        isDead = false;

        attackSpeed = 2.2f;

        canAttack = true;
    }
}
