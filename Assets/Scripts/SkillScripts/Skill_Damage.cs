using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Damage : MonoBehaviour
{
    public LayerMask zombieLayer;
    public float radius;
    public float damageCount;
    public GameObject damageEffect;

    EnemyHealth attackTarget;
    bool collided;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var hits=Physics.OverlapSphere(transform.position, radius,zombieLayer);
        foreach(var c in hits)
        {
            if (c.isTrigger)
            {

            }
            attackTarget = c.gameObject.GetComponent<EnemyHealth>();
            collided = true;
            if (collided)
            {
                Instantiate(damageEffect,transform.position,transform.rotation);
                attackTarget.EnemyTakeDamage(damageCount);
            }
        }
    }
}
