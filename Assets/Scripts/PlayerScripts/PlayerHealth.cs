using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float realHealth = 100f;

    Animator anim;
    bool playerDead;
    bool playerBeHit;

    Slider healthSlider;
    Text healthText;

    BossHealth bossHealth;
    Transform bossTransform;
    bool victory;

    string Animation_Dead = "Dead";
    string Animation_Attack = "Attack";
    string Animation_Victory = "Victory";

    string Base_Layer_Dying = "Base Layer.Dying";
    string Base_Layer_Victory = "Base Layer.Victory";

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //healthSlider=
        //healthText=

        //bossTransform = GameObject.FindGameObjectWithTag("Boss").transform;
        //bossHealth = bossTransform.gameObject.GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (realHealth <= 0)
        {
            realHealth = 0;
            PlayerDying();
        }
        if (playerDead)
        {
            StopPlayerDeadAnimation();
        }
        //if (bossHealth.realHealth <= 0)
        //{
        //    Victory();
        //}
        if (victory)
        {
            StopVictoryAnimation();
        }

    }
    void PlayerDying()
    {
        playerDead = true;
        anim.SetBool(Animation_Dead, true);
        anim.SetBool(Animation_Attack, false);
    }
    void StopPlayerDeadAnimation()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(Base_Layer_Dying))
        {
            anim.SetBool(Animation_Dead, false);
        }
    }
    public void TakeDamage(float amount)
    {
        realHealth-= amount;
        if (realHealth <= 0)
        {
            realHealth = 0;
        }
        if (amount > 0)
        {
            //healthText.text=realHealth.ToString();
            //healthSlider.value=realHealth;
            playerBeHit = true;
        }
    }
    void Victory()
    {
        anim.SetBool(Animation_Victory, true);
        victory = true;
    }
    void StopVictoryAnimation()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(Base_Layer_Victory))
        {
            anim.SetBool(Animation_Victory, false);
        }
    }

}
