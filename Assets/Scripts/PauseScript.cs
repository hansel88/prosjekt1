using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
/*
    public Canvas pauseCanvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            (gameObject.Find("Paddle").GetComponent("PaddleMovement") as MonoBehaviour).enabled = false;
            (gameObject.Find("Main Camera").GetComponent("PaddleMovement") as MonoBehaviour).enabled = false;
            pauseCanvas.enabled = true;
            Time.timeScale = 0;
            Screen.lockCursor = false;
            Screen.showCursor = true;
        }
	}
 * 
 */

    Canvas canvas2;

    void Start()
    {
        canvas2 = GetComponent<Canvas>();
        canvas2.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Pause();
            Screen.showCursor = true;
        }
    }

    public void Pause()
    {
        canvas2.enabled = !canvas2.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void LevelChange(int sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

}
