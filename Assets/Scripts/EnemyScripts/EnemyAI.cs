using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform zombieTransform;

    public float chaseSpeed;

    CapsuleCollider col;
    Transform player;
    Animator anim;
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;
    bool victory;

    string Animation_Attack = "Attack";
    string Animation_Run = "Run";
    string Animation_Speed = "Speed";
    string Animation_Victory = "Victory";

    string Base_Layer_Stand = "Base Layer.Stand";

    NavMeshAgent navAgent;
    public Transform[] navPoints;
    int navigationIndex;

    // Start is called before the first frame update
    void Awake()
    {
        col = GetComponent<CapsuleCollider>();
        anim= GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        zombieTransform = this.transform;
        enemyHealth = GetComponent<EnemyHealth>();
        playerHealth=player.GetComponent<PlayerHealth>();
        navAgent = GetComponent<NavMeshAgent>();
        navigationIndex=Random.Range(0,navPoints.Length);
        navAgent.SetDestination(navPoints[navigationIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        var distance=Vector3.Distance(zombieTransform.position, player.position);
        //if (enemyHealth.realHealth>0)
        //{
        //    if (distance>2.5f)
        //    {
        //        Chase();
        //    }
        //    else
        //    {
        //        Attack();
        //    }
        //    transform.LookAt(player);
        //}

        if (enemyHealth.realHealth > 0)
        {
            if (distance > 7f)
            {
                Search();
                navAgent.Resume();
            }
            else
            {
                navAgent.Stop();
                if (distance > 2.5f)
                {
                    Chase();
                }
                else
                {
                    Attack();
                }
                transform.LookAt(player);

            }
        }
        if(enemyHealth.realHealth < 0)
        {
            col.enabled = false;
        }
        if (playerHealth.realHealth <= 0)
        {
            EnemyVictory();
        }
        if (victory)
        {
            StopVictoryAnimation();
        }

    }
    void Search()
    {
        if (navAgent.remainingDistance <= 0.5f)
        {
            anim.SetFloat(Animation_Speed, 0f);
            anim.SetBool(Animation_Attack, false);
            anim.SetBool(Animation_Run, false);
            if (navigationIndex == navPoints.Length - 1)
            {
                navigationIndex = 0;
            }
            else
            {
                navigationIndex++;
            }
            navAgent.SetDestination(navPoints[navigationIndex].position);
        }
        else
        {
            anim.SetFloat(Animation_Speed, 1f);
            anim.SetBool(Animation_Attack, false);
            anim.SetBool(Animation_Run, false);
        }

    }
    void Chase()
    {
        anim.SetBool(Animation_Run, true);
        anim.SetFloat(Animation_Speed, chaseSpeed);
        anim.SetBool(Animation_Attack, false);
    }
    void Attack()
    {
        anim.SetBool(Animation_Attack, true);
    }
    void EnemyVictory()
    {
        anim.SetBool (Animation_Victory, true);
        victory = true;
    }
    void StopVictoryAnimation()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(Base_Layer_Stand))
        {
            anim.SetBool(Animation_Victory, false);
        }
    }

}
