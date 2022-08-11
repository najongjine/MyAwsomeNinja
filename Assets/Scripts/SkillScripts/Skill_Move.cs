using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Move : MonoBehaviour
{
    public float X, Y, Z;

    public bool local = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (local)
        {
            transform.Translate(new Vector3(X,Y,Z)*Time.deltaTime);
        }
        if (!local)
        {
            transform.Translate(new Vector3(X, Y, Z) * Time.deltaTime,Space.World);
        }

    }
}
