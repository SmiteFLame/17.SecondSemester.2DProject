using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerField : MonoBehaviour
{
    public Text Player_CoolDown_1;
    public Text Player_CoolDown_2;
    public Text Player_CoolDown_3;
    public Text Player_CoolDown_4;
    public Text SpeedText;

    private GameObject HP;
    private GameObject[] Players;
    private GameObject[] enemies;

    private int Player_Class;

    private int Skill_1;
    private int Skill_2;
    private int Skill_3;

    private int enemyCount;
    private bool EndTime = false;

    private float startDelay;
    private float spawnDelay;
    private float startTime;

    private PlayerController PlayerControll;
    private EnemyController EnemyControll;
    private List<EnemyController> Enemy;
    private int Location;
    private bool CheckDeadbyKilled = false;
    private bool MoreEnemy = false;
    private GameObject Player;
    private GameObject Temp;

    private float speedUp;

    void Awake()
    {
        Enemy = new List<EnemyController>();
        spawnDelay = 2f;
        startDelay = 1f;
        startTime = Time.time;
    }

    void Start()
    {
        StartCoroutine(SpawnWaves());
        Player = Instantiate(Players[Player_Class], new Vector3(4 * Location, -3 * Location, 0), Quaternion.identity);
        PlayerControll = Player.GetComponent<PlayerController>();
        PlayerControll.Player_CoolDown_1 = Player_CoolDown_1;
        PlayerControll.Player_CoolDown_2 = Player_CoolDown_2;
        PlayerControll.Player_CoolDown_3 = Player_CoolDown_3;
        PlayerControll.Player_CoolDown_4 = Player_CoolDown_4;
        PlayerControll.SetSkill_1(Skill_1);
        PlayerControll.SetSkill_2(Skill_2);
        PlayerControll.SetSkill_3(Skill_3);
        PlayerControll.SetGHP(HP);
    }
    void Update()
    {
        speedUp = Mathf.Sqrt((Time.time - startTime + 1));
        float x = Mathf.Repeat((Time.time - startTime) * speedUp / 20, 1);
        Vector2 offset = new Vector2(x, 0);

        SpeedText.text = "Speed : " + speedUp.ToString("0.0");
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
        if(MoreEnemy == true)
        {
            StartCoroutine(MoreSpawnWaves());        
            StopCoroutine(MoreSpawnWaves());
            MoreEnemy = false;
        }
        if (PlayerControll.GetPlayerAlive() == false)
        {
            EndTime = true;
            SpeedText.text = Player_CoolDown_1.text = Player_CoolDown_2.text = Player_CoolDown_3.text = Player_CoolDown_4.text = "";
        }
        for (int i = 0; i < Enemy.Count; i++)
        {
            Enemy[i].SetSpeed(speedUp);
            if (Enemy[i].GetKilled() == true)
            {
                Destroy(Enemy[i]);
                Enemy.RemoveAt(i);
                CheckDeadbyKilled = true;
            }
        }
        if (EndTime == true)
            PlayerControll.SetNHP(0);
        for (int i = 0; i < Enemy.Count; i++)
            Enemy[i].SetSpeed(speedUp);

    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            Vector2 spawnPosition = new Vector2(5 * Location * -1, Random.Range(-1.5f, 1.3f) + transform.position.y);
            Quaternion spawnRotation = Quaternion.identity;
            GameObject toInstantiate = enemies[Random.Range(0, enemies.Length)];
            Temp = Instantiate(toInstantiate, spawnPosition, spawnRotation);
            EnemyControll = Temp.GetComponent<EnemyController>();
            Enemy.Add(EnemyControll);
            yield return new WaitForSeconds(spawnDelay * 4 / speedUp);
        }
        
    }

    IEnumerator MoreSpawnWaves()
    {
        Vector2 spawnPosition = new Vector2(5 * Location * -1, Random.Range(-1.3f, 1.3f) + transform.position.y);
        Quaternion spawnRotation = Quaternion.identity;
        GameObject toInstantiate = enemies[Random.Range(0, enemies.Length)];
        Temp = Instantiate(toInstantiate, spawnPosition, spawnRotation);
        EnemyControll = Temp.GetComponent<EnemyController>();
        Enemy.Add(EnemyControll);
        yield return new WaitForSeconds(spawnDelay);
    }

    public void SetObject(int _Location, int _Player_Class, GameObject[] _Players, GameObject[] _enemy, GameObject _HP)
    {
        Location = _Location;
        Player_Class = _Player_Class;
        Players = _Players;
        enemies = _enemy;
        HP = _HP;
    }

    public void SetCheckDeadbyKilled(bool _CheckDeadbyKilled)
    {
        CheckDeadbyKilled = _CheckDeadbyKilled;
    }

    public void SetEndTime(bool _EndTime)
    {
        EndTime = _EndTime;
    }

    public void SetMoreEnemy(bool _MoreEnemy)
    {
        MoreEnemy = _MoreEnemy;
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
    public PlayerController GetPlayerScript()
    {
        return PlayerControll;
    }

    public bool GetCheckDeadbyKilled()
    {
        return CheckDeadbyKilled;
    }

    public bool GetEndTime()
    {
        return EndTime;
    }
}

