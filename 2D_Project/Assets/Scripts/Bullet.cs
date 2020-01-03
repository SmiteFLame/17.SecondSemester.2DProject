using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	
    private float speed = 7;
    private bool star = false;
    private float DeadPoint = 5.5f;

    void Start()
    {
        if (transform.position.y < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
            speed *= -1;
        }
        if (star)
        {
            DeadPoint = 6.0f;
            if (transform.position.y < 0)
                speed *= -1;
        }
    }

	void Update () {
        if (star == false)
            transform.Translate(new Vector3(Time.deltaTime * speed, 0, 0));
        else
        {
            transform.Translate(new Vector3(0, Time.deltaTime * -speed, 0));
        }
        if (Mathf.Abs(transform.position.x) > Mathf.Abs(DeadPoint))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !star)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void SetStar(bool _star)
    {
        star = _star;
    }
}
