using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    Rigidbody2D cactus;
    // Start is called before the first frame update
    void Start()
    {
        cactus = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = GameManager.Instance.gameSpeed / transform.localScale.x ;
        cactus.transform.Translate(-velocity * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
