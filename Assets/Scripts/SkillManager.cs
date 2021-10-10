using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class SkillManager : MonoBehaviour
{
    public float skillSpeed = 5.0f;
    public float skillCooldownTime = 5.0f;
    private bool usingSkill = false;
    public int maxConcurrentUses = 5;
    private int currentConcurrentUses = 0;
    float globalTime = 0.0f;
    float maxGlobalTime;

    void Start()
    {
        maxGlobalTime = maxConcurrentUses * skillCooldownTime;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Exercice 1
            //StartCoroutine("SkillBehaviourCorutine1");
            //Exercice 1 End
            //Exercice 2
            //if (!usingSkill)
            //{
            //    usingSkill = true;
            //    StartCoroutine("SkillBehaviourCorutine2");
            //}
            //Exercice 2 End
            //Exercice 3
            //if (currentConcurrentUses < maxConcurrentUses)
            //{
            //    ++currentConcurrentUses;
            //    StartCoroutine("SkillBehaviourCorutine3");
            //}
            //Exercice 3 end
            //Exercice 4
            if (globalTime < maxGlobalTime)
            {
                globalTime += skillCooldownTime;
                StartCoroutine("SkillBehaviourCorutine4");
            }
            //Exercice 4 end
        }
    }

    //Exercice 1 function
    IEnumerator SkillBehaviourCorutine1()
    {
        //Spawn the object
        GameObject skillInstance = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        skillInstance.transform.position = new Vector3(-15, 0, 0);
        //Move the object for the cooldown time
        System.DateTime myTime = System.DateTime.UtcNow;
        while ((System.DateTime.UtcNow - myTime).Seconds < skillCooldownTime)
        {
            skillInstance.transform.position += new Vector3(skillSpeed * Time.deltaTime, 0, 0);
            yield return null;
        }
        //After the coolown destroy the object
        Destroy(skillInstance);
    }

    //Exercice 2 function: The same as the first one but adding the bool
    IEnumerator SkillBehaviourCorutine2()
    {
        GameObject skillInstance = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        skillInstance.transform.position = new Vector3(-15, 0, 0);
        System.DateTime myTime = System.DateTime.UtcNow;
        while ((System.DateTime.UtcNow - myTime).Seconds < skillCooldownTime)
        {
            skillInstance.transform.position += new Vector3(skillSpeed * Time.deltaTime, 0, 0);
            yield return null;
        }
        Destroy(skillInstance);
        //bool to determine if a skill already is in use
        usingSkill = false;
    }

    //Exercice 3 function: The same as the second one but changing the bool for a count
    IEnumerator SkillBehaviourCorutine3()
    {
        GameObject skillInstance = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        skillInstance.transform.position = new Vector3(-15, 0, 0);
        System.DateTime myTime = System.DateTime.UtcNow;
        while ((System.DateTime.UtcNow - myTime).Seconds < skillCooldownTime)
        {
            skillInstance.transform.position += new Vector3(skillSpeed * Time.deltaTime, 0, 0);
            yield return null;
        }
        Destroy(skillInstance);
        //After we finish the skill we release 1 use of the skill making it aviable
        --currentConcurrentUses;
    }

    //Exercice 4 function: Same idea as the third function but after destroying the object just substract from
    // global time the skillcooldown
    IEnumerator SkillBehaviourCorutine4()
    {
        GameObject skillInstance = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        skillInstance.transform.position = new Vector3(-15, 0, 0);
        System.DateTime myTime = System.DateTime.UtcNow;
        while ((System.DateTime.UtcNow - myTime).Seconds < skillCooldownTime)
        {
            skillInstance.transform.position += new Vector3(skillSpeed * Time.deltaTime, 0, 0);
            yield return null;
        }
        Destroy(skillInstance);
        //After we finish the skill we substract the duration of the skill to the global skill timer
        globalTime -= skillCooldownTime;
    }

}
