using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_RotateObject : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(x, y, z)*Time.deltaTime);
    }
}
