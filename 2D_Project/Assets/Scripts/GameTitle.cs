using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTitle : MonoBehaviour {

    public GameObject Data;
    public GameObject BackGround;
    private GameObject Temp;
    private Data DataScript;

	void Start () {
       Temp = Instantiate(Data);
        DataScript = Temp.GetComponent<Data>();
	}
	
	void Update () {
        if (Input.anyKeyDown)
            StartCoroutine(ChangeGameScene());
	}

    IEnumerator ChangeGameScene()
    {
        DataScript.Loading.SetActive(true);
        BackGround.SetActive(false);
        yield return new WaitForSeconds(3);
        DataScript.Loading.SetActive(false);
        SceneManager.LoadScene("Choose");
    }
}
