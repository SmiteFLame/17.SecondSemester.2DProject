using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : PlayerController {

    void Awake()
    {
        SetStat(2,4,4);
    }

    protected override IEnumerator OwnSkill()
    {
       bool oneTime = false;
         if(oneTime == false)
         {
             oneTime = true;
             SetAttackSpeedRatio(4f);
             yield return new WaitForSeconds(5f);
             SetAttackSpeedRatio(0.25f);
            StopCoroutine(OwnSkill());
        }         
        yield return new WaitForSeconds(5f);
    }
}
