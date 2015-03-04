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
    public GameObject whickedSickSound;
    public GameObject rampageSound;
    public GameObject godlikeSound;
    public GameObject unstoppableSound2;
    public GameObject rampageSound2;
    public GameObject godlikeSound2;
    public GameObject backGroundMusicLev1;
    public GameObject backGroundMusicLev2;

    
    public GameObject bricksPrefab;
    /*
    public GameObject deathParticles;
     * */
    public static GM instance = null;

    private GameObject clonePaddle;
    private int hitCount = 0;
    public int HitCount { get; set; }

    private int bricksHitInARow = 0;
    public int BricksHitInARow { get; set; }
    
    // Use this for initialization
    void Awake()
    {

       // Screen.showCursor = false;

        Debug.Log("awake in GM called");
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        switch (getCurrentLevel())
        {
            case 1: Instantiate(backGroundMusicLev1); break;
            case 2: Instantiate(backGroundMusicLev2); break;
            default: break;
        }
        
        Setup();

    }

    public void Setup()
    {
        Time.timeScale = 1f;
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("loadNextLevel", 1f);
            this.BricksHitInARow = 0;
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
            this.BricksHitInARow = 0;
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
        this.BricksHitInARow = 0;
        resetHitCount();
        lives--;
        livesText.text = "Lives: " + lives;
        //Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    private void resetHitCount()
    {
        this.HitCount = 0;
    }

    private void setMaxVolumeForBackGroundMusic()
    {
        Debug.Log("setmaxvolum called");
        backGroundMusicLev1.GetComponent<AudioSource>().volume = 1f;
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
        int currentLevel = getCurrentLevel();

        if(currentLevel == 1 && this.BricksHitInARow == 4)
        {
            GameObject.Instantiate(whickedSickSound);
        }
        else
        {
            switch (currentLevel)
            {
                case 1:
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
                    break;
                case 2:
                    if (bricks == 60 || bricks == 30)
                    {
                        GameObject.Instantiate(rampageSound2);
                    }
                    else if (bricks == 40 || bricks == 15)
                    {
                        GameObject.Instantiate(godlikeSound2);
                    }
                    else if (bricks == 20 || bricks == 50)
                    {
                        GameObject.Instantiate(unstoppableSound2);
                    }break;
                default: break;
            }
        }
    }

    public int getCurrentLevel()
    {
        switch (Application.loadedLevelName)
        {
            case "Main Menu": return 0;
            case "Scene1": return 1;
            case "Scene2": return 2;
            default: return 0;
        }
    }

    private void loadNextLevel()
    {
        switch(getCurrentLevel())
        {
            case 0: Application.LoadLevel("Scene1"); break;
            case 1: Application.LoadLevel("Scene2"); break;
            case 2: Application.LoadLevel("Main Menu"); break;
        }
    }
}