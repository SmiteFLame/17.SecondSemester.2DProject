using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choose : MonoBehaviour
{
    public GameObject BackGround;
    public GameObject Arrow_1P;
    public GameObject Arrow_2P;
    public GameObject BackGround_1P;
    public GameObject BackGround_2P;


    private int Player1_Class;
    private int Player2_Class;
    private GameObject Data;
    private Data DataScript;

    private bool Choosed_1P;
    private bool Choosed_2P;

    void Awake()
    {
        Data = GameObject.Find("Data(Clone)");
        DataScript = Data.GetComponent<Data>();
    }

    void Start()
    {    
        BackGround_1P.SetActive(false);
        BackGround_2P.SetActive(false);
        Player1_Class = 0;
        Player2_Class = 0;
    }

    void Update()
    {
        if (Choosed_1P == false)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Player1_Class--;
                if (Player1_Class == -1)
                    Player1_Class = 2;
                Move();
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                Player1_Class++;
                if (Player1_Class == 3)
                    Player1_Class = 0;
                Move();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Choosed_1P = true;
                BackGround_1P.SetActive(true);
                Arrow_1P.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                Choosed_2P = false;
                BackGround_2P.SetActive(false);
                Arrow_2P.SetActive(true);
            }
        }

        if (Choosed_2P == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Player2_Class--;
                if (Player2_Class == -1)
                    Player2_Class = 2;
                Move();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Player2_Class++;
                if (Player2_Class == 3)
                    Player2_Class = 0;
                Move();
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                Choosed_2P = true;
                BackGround_2P.SetActive(true);
                Arrow_2P.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Choosed_1P = false;
                BackGround_1P.SetActive(false);
                Arrow_1P.SetActive(true);
            }
        }
        if (Choosed_1P == true && Choosed_2P == true)
        {
            SetGameController();
            StartCoroutine(ChangeGameScene());
        }
    }

    void SetGameController()
    {
        DataScript.SetPlayer1P(Player1_Class);
        DataScript.SetPlayer2P(Player2_Class);
    }

    IEnumerator ChangeGameScene()
    {
        BackGround_1P.SetActive(false);
        BackGround_2P.SetActive(false);
        DataScript.Loading.SetActive(true);
        BackGround.SetActive(false);
        yield return new WaitForSeconds(3);
        DataScript.Loading.SetActive(false);
        SceneManager.LoadScene("MainGame");
    }

    void Move()
    {
        if (Player1_Class == 0)
            Arrow_1P.transform.position = new Vector3(-1.7f, 1.3f, 0);
        else if (Player1_Class == 1)
            Arrow_1P.transform.position = new Vector3(1, 1.3f, 0);
        else if (Player1_Class == 2)
            Arrow_1P.transform.position = new Vector3(3.6f, 1.3f, 0);
        if (Player2_Class == 0)
            Arrow_2P.transform.position = new Vector3(-1.7f, -1.3f, 0);
        else if (Player2_Class == 1)
            Arrow_2P.transform.position = new Vector3(1, -1.3f, 0);
        else if (Player2_Class == 2)
            Arrow_2P.transform.position = new Vector3(3.6f, -1.3f, 0);
    }
}
