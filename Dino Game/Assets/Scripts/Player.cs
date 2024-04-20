using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpVel;
    bool jump;

    Rigidbody2D rbPalyer;
    public Animator dinoAnim;

    // Start is called before the first frame update
    void Start()
    {
        rbPalyer = gameObject.GetComponent<Rigidbody2D>();
        dinoAnim.SetBool("jump", false);
        dinoAnim.SetBool("walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (jump && Input.GetKeyDown(KeyCode.Space) || jump && Input.GetKeyDown(KeyCode.DownArrow))
        {
            rbPalyer.AddForce(Vector2.up * jumpVel, ForceMode2D.Impulse);
            dinoAnim.SetBool("jump", true);
            dinoAnim.SetBool("walk", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = true;
            dinoAnim.SetBool("jump", false);
            dinoAnim.SetBool("walk", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
    }
}
