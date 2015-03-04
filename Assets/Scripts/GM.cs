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
    public Text ScoreText;
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
    public GameObject dominatingSound2;
    public GameObject godlikeSound2;
    public GameObject backGroundMusicLev1;
    public GameObject backGroundMusicLev2;

    
    public GameObject bricksPrefab;
    public static GM instance = null;

    private GameObject clonePaddle;
    private int hitCount = 0;
    public int HitCount {
        get { return this.hitCount; }
        set { this.hitCount = value; }
    }

    private int bricksHitInARow = 0;
    public int BricksHitInARow
    {
        get { return this.bricksHitInARow; }
        set { this.bricksHitInARow = value; }
    }

    private int score = 0;
    public int Score
    {
        get { return this.score; }
        set { this.score = value; }
    }
    
    // Use this for initialization
    void Awake()
    {
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
            this.Score = 0;
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
            this.BricksHitInARow = 0;
            this.Score = 0;
        }

    }

    void Reset()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
        ScoreText.text = "Score: 0";
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
        Debug.Log("hits in a row: " + this.BricksHitInARow);
        if(this.BricksHitInARow <= 1)
        {
            this.Score += 1;
        }
        else
        {
            this.Score += this.BricksHitInARow * 2;
        }

        ScoreText.text = "Score: " + this.Score;
        bricks--;
        CheckGameOver();
        Invoke("checkAwesomeness", 0.5f);
    }

    private void checkAwesomeness()
    {
        int currentLevel = getCurrentLevel();

        if(this.BricksHitInARow == 4)
        {
            if(currentLevel == 1)
            {
                GameObject.Instantiate(whickedSickSound);
            }
            else if(currentLevel == 2)
                GameObject.Instantiate(dominatingSound2);
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
                    if (bricks == 30)
                    {
                        GameObject.Instantiate(dominatingSound2);
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