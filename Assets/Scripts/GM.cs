using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour
{

    public int lives = 3;
    public int bricks = 72;
    public float resetDelay = 1f;
    public GameObject paddle;
    
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject youWonSound;
    public GameObject gameOverSound;
    public GameObject unstoppableSound;
    public GameObject holyShitSound;
    public GameObject rampageSound;
    public GameObject godlikeSound;
    public GameObject backGroundMusicLev1;

    
    public GameObject bricksPrefab;
    /*
    public GameObject deathParticles;
     * */
    public static GM instance = null;

    private GameObject clonePaddle;

    // Use this for initialization
    void Awake()
    {

       // Screen.showCursor = false;

        Debug.Log("awake in GM called");
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Instantiate(backGroundMusicLev1);
        Setup();

    }

    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

    }

    void Reset()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseLife()
    {
       // backGroundMusicLev1.GetComponent<AudioSource>().volume = 0.1f;
       // backGroundMusicLev1.audio.volume = 0.1f;
        //Invoke("setMaxVolumeForBackGroundMusic", 3);
        lives--;
        livesText.text = "Lives: " + lives;
        //Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    private void setMaxVolumeForBackGroundMusic()
    {
        backGroundMusicLev1.audio.volume = 1f;
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        Invoke("playSoundCheck", 0.5f);
        bricks--;
        CheckGameOver();
    }

    private void playSoundCheck()
    {
        if (bricks == 60 || bricks == 30)
        {
            GameObject.Instantiate(holyShitSound);
        }
        else if (bricks == 40 || bricks == 15)
        {
            GameObject.Instantiate(rampageSound);
        }
        else if (bricks == 20 || bricks == 50)
        {
            GameObject.Instantiate(unstoppableSound);
        }
        else if (bricks == 2 || bricks == 35)
        {
            GameObject.Instantiate(godlikeSound);
        }
    }
}