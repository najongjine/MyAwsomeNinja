using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCol : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float radius;
    public GameObject attackEffect;

    public Transform hitPoint;
    public float damageCount;

    EnemyHealth enemyHealth;
    bool collided;

    // Start is called before the first frame update
    void OnDisable()
    {
        if(enemyHealth != null)
        {
            enemyHealth = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var hits=Physics.OverlapSphere(hitPoint.position, radius,enemyLayer);
        foreach(var c in hits)
        {
            if (c.isTrigger)
            {
                continue;
            }
            enemyHealth=c.gameObject.GetComponent<EnemyHealth>();
            collided = true;
            if (collided)
            {
                Instantiate(attackEffect, hitPoint.position, hitPoint.rotation);
                enemyHealth.EnemyTakeDamage(damageCount);
            }
        }
        

    }
}
