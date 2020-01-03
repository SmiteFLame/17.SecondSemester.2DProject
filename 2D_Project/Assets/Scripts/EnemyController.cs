using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float ownSpeed;
    public int HP;
    private int Location;
    private float speed;
    private bool Killed = false;

    void Awake()
    {
        Location = (int)transform.position.y / (int)Mathf.Abs(transform.position.y);
        if (Location == 1)
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
           
    }
    void Update()
    {
        transform.Translate(new Vector3((float)Location * Time.deltaTime * speed / 4 * ownSpeed * -1, 0, 0));

        if (Mathf.Abs(transform.position.x) > Mathf.Abs(5.5f))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        if(HP <= 0)
        {
            gameObject.SetActive(false);
            Killed = true;
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            HP--;
        }
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    public bool GetKilled()
    {
        return Killed;
    }

    public void EndGame()
    {
        gameObject.SetActive(false);
        Destroy(this);
    }
}