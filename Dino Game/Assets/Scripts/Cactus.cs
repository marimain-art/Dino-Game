using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    int cactusSpawn;
    Rigidbody2D cactus;
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        cactusSpawn = Random.Range(0, 2);
        cactus = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
