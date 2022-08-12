using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour
{
    public GameObject attackPointOne;
    public GameObject attackPointTwo;
    public GameObject enemyAttackEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EnemyAttackOne(bool attacking)
    {
        if (attacking)
        {
            Instantiate(enemyAttackEffect, attackPointOne.transform.position, attackPointOne.transform.rotation);
        }
    }
    void EnemyAttackTwo(bool attacking)
    {
        if (attacking)
        {
            Instantiate(enemyAttackEffect, attackPointTwo.transform.position, attackPointTwo.transform.rotation);
        }
    }
    void EnemyAttackOneStart(bool attackStarted)
    {
        if (attackStarted)
        {
            attackPointOne.SetActive(true);
        }
    }
    void EnemyAttackOneEnd(bool attackEnd)
    {
        if (attackEnd)
        {
            attackPointOne.SetActive(false);
        }
    }
    void EnemyAttackTwoStart(bool attackStarted)
    {
        if (attackStarted)
        {
            attackPointTwo.SetActive(true);
        }
    }
    void EnemyAttackTwoEnd(bool attackEnd)
    {
        if (attackEnd)
        {
            attackPointTwo.SetActive(false);
        }
    }

}

