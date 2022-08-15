using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartMove : MonoBehaviour
{
    SphereCollider col;
    BossAI bossAI;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SphereCollider>();
        bossAI = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossAI>();
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            bossAI.enabled = true;
            col.enabled = false;
        }
    }
}
