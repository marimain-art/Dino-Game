using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpVel;
    bool jump;

    Rigidbody2D rbPalyer;
    public Animator dinoAnim;

    public Button start;
    public Button restart;
    public Image gameOverImage;
    public Text scoreText;

    public AudioSource gameAudio;
    public AudioClip[] gameSounds;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        GameManager.Instance.UpsdateHiScore();
        rbPalyer = gameObject.GetComponent<Rigidbody2D>();

        dinoAnim.SetBool("jump", false);
        dinoAnim.SetBool("walk", true);
        dinoAnim.SetBool("die", false);

        start.gameObject.SetActive(true);
        restart.gameObject.SetActive(false);
        gameOverImage.gameObject.SetActive(false);
        restart.onClick.AddListener(Restart);
        start.onClick.AddListener(Starting);
        GameManager.Instance.gameSpeed = GameManager.Instance.initialGameSpeed;
        gameAudio.PlayOneShot(gameSounds[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (jump && Input.GetKeyDown(KeyCode.Space) || jump && Input.GetKeyDown(KeyCode.DownArrow))
        {
            rbPalyer.AddForce(Vector2.up * jumpVel, ForceMode2D.Impulse);
            dinoAnim.SetBool("jump", true);
            dinoAnim.SetBool("walk", false);
            gameAudio.PlayOneShot(gameSounds[1]);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameAudio.PlayOneShot(gameSounds[3]);
            jump = true;
            dinoAnim.SetBool("jump", false);
            dinoAnim.SetBool("walk", true);
        }
        else if (collision.gameObject.CompareTag("Cactus"))
        {
            GameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
    }

    public void Starting()
    {
        GameManager.Instance.gameSpeed = GameManager.Instance.initialGameSpeed;
        GameManager.Instance.UpsdateHiScore();
        start.gameObject.SetActive(false);
        gameOverImage.gameObject.SetActive(false);
        Time.timeScale = 1;

    }

    public void Restart()
    {
        restart.gameObject.SetActive(false);
        gameOverImage.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    private void GameOver()
    {
        gameAudio.PlayOneShot(gameSounds[2]);
        Time.timeScale = 0;
        restart.gameObject.SetActive(true);
        gameOverImage.gameObject.SetActive(true);
        dinoAnim.SetBool("jump", false);
        dinoAnim.SetBool("walk", false);
        dinoAnim.SetBool("die", true);
        GameManager.Instance.UpsdateHiScore();
    }
}
