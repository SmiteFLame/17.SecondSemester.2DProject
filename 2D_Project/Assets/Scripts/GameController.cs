using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Text ExitText;
    public Text TimeText;
    public GameObject KeyButton;

    public GameObject[] Player;
    public GameObject[] enemy;
    public GameObject HP;

    public GameObject Player1_BackGround;
    public GameObject Player2_BackGround;

    private GameObject Data;
    private Data DataScript;
    private int Player1_Class;
    private int Player2_Class;

    private float TimeCount = 0;
    private int Skill1P_1;
    private int Skill1P_2;
    private int Skill1P_3;
    private int Skill2P_1;
    private int Skill2P_2;
    private int Skill2P_3;

    private GameObject ExitImage; 
    private PlayerField Player1_BackGround_Script;
    private PlayerField Player2_BackGround_Script;


    void Awake()
    {
        Data = GameObject.Find("Data(Clone)");
        DataScript = Data.GetComponent<Data>();
        Player1_Class = DataScript.GetPlayer1P();
        Player2_Class = DataScript.GetPlayer2P();
        ExitText.text = " ";
        ExitImage = GameObject.Find("ExitImage");
        ExitImage.SetActive(false);
        KeyButton.SetActive(false);

        Player1_BackGround_Script = Player1_BackGround.GetComponent<PlayerField>();
        Player2_BackGround_Script = Player2_BackGround.GetComponent<PlayerField>();
        Player1_BackGround_Script.SetSkill_1(Skill1P_1);
        Player1_BackGround_Script.SetSkill_2(Skill1P_2);
        Player1_BackGround_Script.SetSkill_3(Skill1P_3);
        Player2_BackGround_Script.SetSkill_1(Skill2P_1);
        Player2_BackGround_Script.SetSkill_2(Skill2P_2);
        Player2_BackGround_Script.SetSkill_3(Skill2P_3);

        Player1_BackGround_Script.SetObject(-1,Player1_Class, Player, enemy, HP);
        Player2_BackGround_Script.SetObject(1,Player2_Class, Player, enemy, HP);

    }

    void Update()
    {
        TimeCount += Time.deltaTime;
        int Minute = (int)TimeCount / 60;
        float Second = (int)TimeCount % 60;
        TimeText.text = Minute.ToString("00") + " : " + Second.ToString("00");

        if (TimeCount <= 0)
        {
            TimeText.text = "00 : 00";
        }

        if (Player1_BackGround_Script.GetCheckDeadbyKilled() == true)
        {
            Player2_BackGround_Script.SetMoreEnemy(true);
            Player1_BackGround_Script.SetCheckDeadbyKilled(false);
        }

        if (Player2_BackGround_Script.GetCheckDeadbyKilled() == true)
        {
            Player1_BackGround_Script.SetMoreEnemy(true);
            Player2_BackGround_Script.SetCheckDeadbyKilled(false);
        }

        if (Player1_BackGround_Script.GetEndTime() == true || Player2_BackGround_Script.GetEndTime() == true)
        {
            ExitImage.SetActive(true);
            KeyButton.SetActive(true);

            if (Player1_BackGround_Script.GetEndTime() == true)
            {
                ExitText.text = "2P WIN!!";
                Player1_BackGround_Script.SetEndTime(true);
            }
            else
            {
                ExitText.text = "1P WIN!!";
                Player2_BackGround_Script.SetEndTime(true);
            }

            TimeText.text = "";
            Destroy(GameObject.Find("Hunter(Clone)"));
            Destroy(GameObject.Find("Mage(Clone)"));
            Destroy(GameObject.Find("Priest(Clone)"));
            Destroy(Player1_BackGround);
            Destroy(Player2_BackGround);
            if (Input.anyKeyDown)
                StartCoroutine(ChangeGameScene());
        }
    }
    IEnumerator ChangeGameScene()
    {
        DataScript.Loading.SetActive(true);
        yield return new WaitForSeconds(3);
        DataScript.Loading.SetActive(false);
        SceneManager.LoadScene("Choose");
    }
}
