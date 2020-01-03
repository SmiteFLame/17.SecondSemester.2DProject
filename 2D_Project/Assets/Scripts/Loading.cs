using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour {

    public GameObject LoadingText;
    public GameObject LoadingArrow;

	void Update ()
    {
        LoadingText.transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
        LoadingArrow.transform.Rotate(new Vector3(0, 0, 90) * -Time.deltaTime);
    }
}
