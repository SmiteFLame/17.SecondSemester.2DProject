using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerController : MonoBehaviour {

    public Text Player_CoolDown_1;
    public Text Player_CoolDown_2;
    public Text Player_CoolDown_3;
    public Text Player_CoolDown_4;

    public GameObject bullet;

    private int nHP;
    private float speed;
    private float attackSpeed;

    public int Location;
    private GameObject HP;
    private GameObject Temp;
    private List<GameObject> HPS;

    private int Skill_1;
    private int Skill_2;
    private int Skill_3;

    private float CoolDown_1;
    private float CoolDown_2;
    private float CoolDown_3;
    private float CoolDown_4;

    private float nextFire;
    private bool PlayerAlive = true;
    private bool undead = false;

    void Start()
    {
        CoolDown_1 = 0f;
        CoolDown_2 = 0f;
        CoolDown_3 = 0f;
        CoolDown_4 = 0f;
        HPS = new List<GameObject>();
        Location = (int)transform.position.y / (int)Mathf.Abs(transform.position.y);
        if (Location == 1)
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        for(int i = 0; i < nHP; i++)
        {
            Temp = Instantiate(HP, new Vector3(-(5f - i) * Location, 2f * Location, 0), Quaternion.identity);
            HPS.Add(Temp);
        }
        speed *= 0.025f;
        nextFire = Time.time + 0.25f;
    }

    void Update()
    {
        SetText();
        CoolDown_1 -= Time.deltaTime;
        CoolDown_2 -= Time.deltaTime;
        CoolDown_3 -= Time.deltaTime;
        CoolDown_4 -= Time.deltaTime;
        if (Time.time > nextFire)
        {  
            Instantiate(bullet, this.transform.position, Quaternion.identity);
            nextFire += 1f / attackSpeed;         
        }
        if (Location == 1)
        {
            if (Input.GetKey(KeyCode.F))
            {
                gameObject.transform.Translate(0.0f, speed, 0.0f);
            }
            if (Input.GetKey(KeyCode.V))
            {
                gameObject.transform.Translate(0.0f, -speed, 0.0f);
            }
            if (Input.GetKey(KeyCode.B))
            {
                gameObject.transform.Translate(speed, 0.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.C))
            {
                gameObject.transform.Translate(-speed, 0.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.Q) && CoolDown_1 <= 0)//S1
            {
                SKill(Skill_1);
                CoolDown_1 = 45;
            }
            if (Input.GetKey(KeyCode.W) && CoolDown_2 <= 0)//S2
            {
                SKill(Skill_2);
                CoolDown_2 = 45;
            }
            if (Input.GetKey(KeyCode.A) && CoolDown_3 <= 0)//S3
            {
                SKill(Skill_3);
                CoolDown_3 = 45;
            }
            if (Input.GetKey(KeyCode.S) && CoolDown_4 <= 0)//S4
            {
                StartCoroutine(OwnSkill());
                CoolDown_4 = 35;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                gameObject.transform.Translate(0.0f, speed, 0.0f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.transform.Translate(0.0f, -speed, 0.0f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.Translate(speed, 0.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.Translate(-speed, 0.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.I) && CoolDown_1 <= 0)//S1
            {
                SKill(Skill_1);
                CoolDown_1 = 45;
            }
            if (Input.GetKey(KeyCode.O) && CoolDown_2 <= 0)//S2
            {
                SKill(Skill_2);
                CoolDown_2 = 45;
            }
            if (Input.GetKey(KeyCode.K) && CoolDown_3 <= 0)//S3
            {
                SKill(Skill_3);
                CoolDown_3 = 45;
            }
            if (Input.GetKey(KeyCode.L) && CoolDown_4 <= 0)//S4
            {
                StartCoroutine(OwnSkill());
                CoolDown_4 = 35;

            }
        }
        
        if (nHP <= 0)
        {
            PlayerAlive = false;
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    void SetText()
    {
        if (CoolDown_1 < 0f || CoolDown_1 > 40)
            Player_CoolDown_1.text = "00";
        else
            Player_CoolDown_1.text = CoolDown_1.ToString("00");
        if (CoolDown_2 < 0f || CoolDown_2 > 40)
            Player_CoolDown_2.text = "00";
        else
            Player_CoolDown_2.text = CoolDown_2.ToString("00");
        if (CoolDown_3 < 0f || CoolDown_3 > 40)
            Player_CoolDown_3.text = "00";
        else
            Player_CoolDown_3.text = CoolDown_3.ToString("00");
        if (CoolDown_4 < 0f || CoolDown_4 > 30)
            Player_CoolDown_4.text = "00";
        else
            Player_CoolDown_4.text = CoolDown_4.ToString("00");

    }
    void SKill(int Number)
    {

    }

    protected abstract IEnumerator OwnSkill();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && undead == false)
        {
            Destroy(HPS[nHP - 1]);
            HPS.RemoveAt(nHP - 1);
            nHP--;
        }
    }
    public bool GetPlayerAlive()
    {
        return PlayerAlive;
    }

    public void SetGHP(GameObject _HP)
    {
        HP = _HP;
    }

    public void SetStat(int _nHP, int _speed, int _attackSpeed)
    {
        nHP = _nHP;
        speed = _speed;
        attackSpeed = _attackSpeed;
    }

    public void SetAttackSpeedRatio(float _attackSpeed)
    {
        attackSpeed *= _attackSpeed;
    }

    public void SetNHP(int _nHP)
    {
        nHP = _nHP;
    }

    public void SetUnDead(bool _undead)
    {
        undead = _undead;
    }

    public void SetSkill_1(int _Skill_1)
    {
        Skill_1 = _Skill_1;
    }

    public void SetSkill_2(int _Skill_2)
    {
        Skill_2 = _Skill_2;
    }

    public void SetSkill_3(int _Skill_3)
    {
        Skill_3 = _Skill_3;
    }
}
