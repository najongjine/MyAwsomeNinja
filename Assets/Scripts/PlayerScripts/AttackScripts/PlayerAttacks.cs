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
    AudioSource audioSource;

    bool s1_NotUsed;
    bool s2_NotUsed;
    bool s3_NotUsed;

    string Animation_Attack = "Attack";
    string Animation_Skill_1 = "Skill1";
    string Animation_Skill_2 = "Skill2";
    string Animation_Skill_3 = "Skill3";

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        s1_NotUsed = true;
        s2_NotUsed = true;
        s3_NotUsed = true;
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
        if (Input.GetKeyUp(KeyCode.J))
        {
            if (s1_NotUsed)
            {
                s1_NotUsed = false;
                anim.SetBool(Animation_Skill_1, true);
                StartCoroutine(ResetSkill(1));
            }
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            if (s2_NotUsed)
            {
                s2_NotUsed = false;
                anim.SetBool(Animation_Skill_2, true);
                StartCoroutine(ResetSkill(2));
            }
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            if (s3_NotUsed)
            {
                s3_NotUsed = false;
                anim.SetBool(Animation_Skill_3, true);
                StartCoroutine(ResetSkill(3));
            }
        }

    }
    void SkillOne(bool skillOne)
    {
        if (skillOne)
        {
            Instantiate(skillOne_EffectPrefab, skillOne_Point.position, skillOne_Point.rotation);
            audioSource.PlayOneShot(skillOneMusic1);
            StartCoroutine(SkillOneCoroutine());
        }
    }
    void SkillOneSound(bool play)
    {
        if (play)
        {
            audioSource.PlayOneShot(playerSkillOneSound);
        }
    }
    void SkillOneEnd(bool skillOneEnd)
    {
        if (skillOneEnd)
        {
            anim.SetBool(Animation_Skill_1, false);
        }
    }
    IEnumerator SkillOneCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_1.position, skillOnePoint_1.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_2.position, skillOnePoint_2.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_3.position, skillOnePoint_3.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_4.position, skillOnePoint_4.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_5.position, skillOnePoint_5.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_6.position, skillOnePoint_6.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_7.position, skillOnePoint_7.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_8.position, skillOnePoint_8.rotation);
    }

    void SkillTwo(bool skillTwo)
    {
        if (skillTwo)
        {
            Instantiate(skillTwo_EffectPrefab, skillTwo_Point.position, skillTwo_Point.rotation);
            audioSource.PlayOneShot(skillTwoMusic);
            StartCoroutine(SkillTwoCoroutine());
        }
    }
    void SkillTwoEnd(bool skillTwoEnd)
    {
        if (skillTwoEnd)
        {
            anim.SetBool(Animation_Skill_2, false);
        }
    }
    IEnumerator SkillTwoCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_1.position, skillTwoPoint_1.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_2.position, skillTwoPoint_2.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_3.position, skillTwoPoint_3.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_4.position, skillTwoPoint_4.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_5.position, skillTwoPoint_5.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_6.position, skillTwoPoint_6.rotation);
    }

    void SkillThree(bool skillThree)
    {
        if (skillThree)
        {
            Instantiate(skillThree_EffectPrefab, skillThreePoint_1.position, skillThreePoint_1.rotation);
            Instantiate(skillThree_EffectPrefab, skillThreePoint_2.position, skillThreePoint_2.rotation);
            Instantiate(skillThree_EffectPrefab, skillThreePoint_3.position, skillThreePoint_3.rotation);
            Instantiate(skillThree_EffectPrefab, skillThreePoint_4.position, skillThreePoint_4.rotation);
            Instantiate(skillThree_EffectPrefab, skillThreePoint_5.position, skillThreePoint_5.rotation);
        }
    }
    void SkillThreeEnd(bool skillThreeEnd)
    {
        if (skillThreeEnd)
        {
            anim.SetBool(Animation_Skill_3, false);
        }
    }
    IEnumerator ResetSkill(int skill)
    {
        yield return new WaitForSeconds(3f);
        switch (skill)
        {
            case 1:
                s1_NotUsed = true;
                break;
            case 2:
                s2_NotUsed = true;
                break;
            case 3:
                s3_NotUsed = true;
                break;
        }
    }

}
