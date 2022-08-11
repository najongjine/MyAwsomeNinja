using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Effect : MonoBehaviour
{
    public LayerMask ignoreLayers;
    public GameObject skillEffectPrefab;
    public float radius;

    bool collided = false;


    // Update is called once per frame
    void Update()
    {
        var hits=Physics.OverlapSphere(transform.position, radius,~ignoreLayers);
        foreach(var c in hits)
        {
            if (c.isTrigger)
            {
                continue;
            }
            collided = true;
        }
        if (collided)
        {
            Instantiate(skillEffectPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
