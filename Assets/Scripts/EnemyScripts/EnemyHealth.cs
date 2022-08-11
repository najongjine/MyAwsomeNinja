using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float realHealth;

    AudioSource audioSource;
    public AudioClip enemyDeadSound;

    bool enemyDead;
    Animator anim;
    bool enemyIsHit;

    public GameObject deadEffect;
    public Transform deadEffectPoint;

    public GameObject attackPointOne;
    public GameObject attackPointTwo;

    string Animation_Attack = "Attack";
    string Animation_Be_Attacked = "BeAttacked";
    string Animation_Dead = "Dead";

    string Base_Layer_Dying = "Base Layer.Dying";
    string Base_Layer_Hit = "Base Layer.Hit";

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDead)
        {
            StopDeadAnimation();
        }
        if (enemyIsHit)
        {
            EnemyAttacked();
        }
        if (!enemyIsHit)
        {
            StopEnemyHit();
        }

    }
    void EnemyDying()
    {
        anim.SetBool(Animation_Dead, true);
        anim.SetBool(Animation_Be_Attacked, false);
        enemyDead = true;
        StartCoroutine(deadEffect());
        attackPointOne.SetActive(false);
        attackPointTwo.SetActive(false);
        audioSource.PlayOneShot(enemyDeadSound);
    }
    void StopDeadAnimation()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(Base_Layer_Dying))
        {
            anim.SetBool(Animation_Dead, false);
        }
    }
    public void EnemyTakeDamage(float amount)
    {
        realHealth-=amount;
        if(realHealth <= 0)
        {
            realHealth = 0;
            EnemyDying();
        }
        if (amount > 0)
        {
            enemyIsHit = true;
        }
    }
    void EnemyAttacked()
    {
        enemyIsHit=false;
        anim.SetBool(Animation_Be_Attacked, true);
        anim.SetBool(Animation_Attack, false);
        transform.Translate(Vector3.back * 0.5f);
    }
    void StopEnemyHit()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(Base_Layer_Hit))
        {
            anim.SetBool(Animation_Be_Attacked, false);
        }
    }
    IEnumerator DeadEffect()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(deadEffect, deadEffectPoint.position, deadEffectPoint.rotation);
        Destroy(gameObject);
    }

}
