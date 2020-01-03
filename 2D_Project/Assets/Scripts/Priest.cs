using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : PlayerController
{
    public GameObject Shield;
    private float SkillTime;
    void Awake()
    {
        Shield.SetActive(false);
        SetStat(4, 3, 2);
    }
    protected override IEnumerator OwnSkill()
    {
        Shield.SetActive(true);
        SetUnDead(true);
        yield return new WaitForSeconds(5f);
        Shield.SetActive(false);
        SetUnDead(false);
    }
}
