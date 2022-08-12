using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollision : MonoBehaviour
{
    public LayerMask playerLayer;
    public float radius;
    bool collided;

    public Transform hitPoint;
    public float damageCount;

    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        var hits = Physics.OverlapSphere(hitPoint.position,radius,playerLayer);
        foreach(var c in hits)
        {
            if (c.isTrigger)
            {
                continue;
            }
            collided = true;
            if (collided)
            {
                playerHealth.TakeDamage(damageCount);
            }
        }
        
    }
}
