using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    Animator anim;
    Transform playerTransform;
    PlayerHealth playerHealth;
    BossHealth bossHealth;

    string Animation_Skill1 = "Skill1";
    string Animation_Skill2 = "Skill2";
    string Animation_Skill3 = "Skill3";
    string Animation_Walk = "Walk";
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth=playerTransform.gameObject.GetComponent<PlayerHealth>();
        bossHealth=GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        var distance=Vector3.Distance(transform.position,playerTransform.position);
        if (bossHealth.realHealth > 0)
        {
            transform.LookAt(playerTransform);
        }
        if(playerHealth.realHealth <= 0)
        {
            anim.SetBool(Animation_Skill1, false);
            anim.SetBool(Animation_Skill2, false);
            anim.SetBool(Animation_Skill3, false);
            anim.SetBool(Animation_Walk, false);
        }
        if (bossHealth.realHealth > 0)
        {
            if (distance>5)
            {
                anim.SetBool(Animation_Skill1, false);
                anim.SetBool(Animation_Skill2, false);
                anim.SetBool(Animation_Skill3, false);
                anim.SetBool(Animation_Walk, true);
            }
            else
            {
                anim.SetBool(Animation_Walk, false);
                if (distance > 2.5f)
                {
                    anim.SetBool(Animation_Skill1, true);
                    anim.SetBool(Animation_Skill2, false);
                    anim.SetBool(Animation_Skill3, false);
                }
                if (distance <= 2.5f && distance>0.5f )
                {
                    anim.SetBool(Animation_Skill1, false);
                    anim.SetBool(Animation_Skill2, true);
                    anim.SetBool(Animation_Skill3, false);
                }
                if (distance <= 0.5f)
                {
                    anim.SetBool(Animation_Skill1, false);
                    anim.SetBool(Animation_Skill2, false);
                    anim.SetBool(Animation_Skill3, true);
                }
            }
        }

    }
}
