using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyMoving : MonoBehaviour {

    private float ScrollSpeed = 0.5f;
    float x = 0;

    void Update()
    {     
        x += Time.deltaTime * ScrollSpeed;
        Vector2 Offset = new Vector2(x, 0);
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", Offset);
    }
}
