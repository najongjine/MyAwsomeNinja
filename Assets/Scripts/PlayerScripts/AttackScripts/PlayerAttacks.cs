using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public GameObject skillOne_EffectPrefab;
    public GameObject skillOne_DamagePrefab;

    public Transform skillOne_Point;
    public Transform skillOnePoint_1;
    public Transform skillOnePoint_2;
    public Transform skillOnePoint_3;
    public Transform skillOnePoint_4;
    public Transform skillOnePoint_5;
    public Transform skillOnePoint_6;
    public Transform skillOnePoint_7;
    public Transform skillOnePoint_8;

    public GameObject skillTwo_EffectPrefab;
    public GameObject skillTwo_DamagePrefab;

    public Transform skillTwo_Point;
    public Transform skillTwoPoint_1;
    public Transform skillTwoPoint_2;
    public Transform skillTwoPoint_3;
    public Transform skillTwoPoint_4;
    public Transform skillTwoPoint_5;
    public Transform skillTwoPoint_6;

    public GameObject skillThree_EffectPrefab;

    public Transform skillThreePoint_1;
    public Transform skillThreePoint_2;
    public Transform skillThreePoint_3;
    public Transform skillThreePoint_4;
    public Transform skillThreePoint_5;

    public AudioClip skillOneMusic1;
    public AudioClip skillOneMusic2;
    public AudioClip playerSkillOneSound;
    public AudioClip skillTwoMusic;
    public AudioClip skillThreeMusic;

    Animator anim;

    string Animation_Attack = "Attack";
    string Animation_Skill_1 = "Skill1";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleButtonPresses();
    }
    void HandleButtonPresses()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            anim.SetBool(Animation_Attack, true);
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            anim.SetBool(Animation_Attack, false);
        }

    }

}
