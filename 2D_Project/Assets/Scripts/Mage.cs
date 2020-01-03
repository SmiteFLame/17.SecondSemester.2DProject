using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : PlayerController
{
    public GameObject StarBrust;
    private GameObject Temp;
    private Bullet BTemp;
    void Awake()
    {
        SetStat(3, 3, 3);
    }
    protected override IEnumerator OwnSkill()
    {
        Temp = Instantiate(StarBrust, new Vector3(-4 * Location, 2.3f * Location,0), Quaternion.identity);
        BTemp = Temp.GetComponent<Bullet>();
        BTemp.SetStar(true);
        Temp.transform.Rotate(0, 0, 90 * Location);
        yield return new WaitForSeconds(0.2f);
        Temp = Instantiate(StarBrust, new Vector3(-4 * Location, 4.3f * Location, 0), Quaternion.identity);
        BTemp = Temp.GetComponent<Bullet>();
        BTemp.SetStar(true);
        Temp.transform.Rotate(0, 0, 90 * Location);
        yield return new WaitForSeconds(0.2f);
        Temp = Instantiate(StarBrust, new Vector3(-4 * Location, 3.3f * Location, 0), Quaternion.identity);
        BTemp = Temp.GetComponent<Bullet>();
        BTemp.SetStar(true);
        Temp.transform.Rotate(0, 0, 90 * Location);
        yield return new WaitForSeconds(0.2f);
    }

    private void Instantiate(GameObject starBrust, Vector3 vector31, Vector3 vector32)
    {
        throw new NotImplementedException();
    }
}
