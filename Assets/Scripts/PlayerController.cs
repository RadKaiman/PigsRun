using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float jumpForce = 15;
    public float gravityModifier;
    public bool gameOver = false;
    public bool win = false;
    public bool pause = false;
    public bool isOnGround = true;

    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] Text scoreText;

    private int scoreAcorns = 0;
    public int scoreGeneralAcorns;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gravityModifier = 6;
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        scoreAcorns = 0;
        scoreText.text = scoreAcorns.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))  // если нажата клавиша Esc (Escape)
        {
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * 6);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            losePanel.SetActive(true);
            Invoke("Restart", 2);
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            win = true;
            Debug.Log("You Win!!!");
            winPanel.SetActive(true);
            scoreGeneralAcorns += scoreAcorns;
            Invoke("Win", 2);
        }
        else if (collision.gameObject.CompareTag("Acorns"))
        {
            scoreAcorns++;
            scoreText.text = scoreAcorns.ToString();
            Destroy(collision.gameObject);
        }
    }

    public void Win()
    {
        PlayerPrefs.SetInt("score", scoreAcorns);
        PlayerPrefs.Save();
        FindObjectOfType<MenuGame>().BackToMenu();
    }

    public void Restart()
    {
        Physics.gravity /= gravityModifier;
        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        if (pause == true)
        {
            pause = false;
            Cursor.lockState = CursorLockMode.Locked;
            pausePanel.SetActive(false);         
            FindObjectOfType<MoveLeft>().pauseMoveLeft = false;
            //FindObjectOfType<MoveRight>().pauseMoveRight = false;
            FindObjectOfType<SpawnManager>().pauseSpawn = false;
            FindObjectOfType<RepeatBackground>().pauseBack = false;
        }
        else
        {
            pause = true;
            Cursor.lockState = CursorLockMode.None;
            pausePanel.SetActive(true);
            FindObjectOfType<MoveLeft>().pauseMoveLeft = true;
            //FindObjectOfType<MoveRight>().pauseMoveRight = true;
            FindObjectOfType<SpawnManager>().pauseSpawn = true;
            FindObjectOfType<RepeatBackground>().pauseBack = true;
        }
    }
}
