using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

    public GameObject Loading;

    private int Player1P_Class;
    private int Player1P_Skill_1;
    private int Player1P_Skill_2;
    private int Player1P_Skill_3;

    private int Player2P_Class;
    private int Player2P_Skill_1;
    private int Player2P_Skill_2;
    private int Player2P_Skill_3;

    void Awake()
    {
        Loading.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayer1P(int _Player1P_Class)
    {
        Player1P_Class = _Player1P_Class;
    }

    public void SetPlayer2P(int _Player2P_Class)
    {
        Player2P_Class = _Player2P_Class;
    }

    public void SetPlayer1P_Skill(int _Player1P_Skill_1, int _Player1P_Skill_2, int _Player1P_Skill_3)
    {
        Player1P_Skill_1 = _Player1P_Skill_1;
        Player1P_Skill_2 = _Player1P_Skill_2;
        Player1P_Skill_3 = _Player1P_Skill_3;
    }
    public void SetPlayer2P_Skill(int _Player2P_Skill_1, int _Player2P_Skill_2, int _Player2P_Skill_3)
    {
        Player2P_Skill_1 = _Player2P_Skill_1;
        Player2P_Skill_2 = _Player2P_Skill_2;
        Player2P_Skill_3 = _Player2P_Skill_3;
    }

    public int GetPlayer1P()
    {
        return Player1P_Class;
    }

    public int GetPlayer2P()
    {
        return Player2P_Class;
    }

    public int GetPlayer1P_Skill_1()
    {
        return Player1P_Skill_1;
    }

    public int GetPlayer1P_Skill_2()
    {
        return Player1P_Skill_2;
    }

    public int GetPlayer1P_Skill_3()
    {
        return Player1P_Skill_3;
    }

    public int GetPlayer2P_Skill_1()
    {
        return Player2P_Skill_1;
    }

    public int GetPlayer2P_Skill_2()
    {
        return Player2P_Skill_2;
    }

    public int GetPlayer2P_Skill_3()
    {
        return Player2P_Skill_3;
    }
}
