using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

    public Canvas canvas2;

    void Start()
    {
        canvas2.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
            Screen.showCursor = true;
        }
    }

    public void TogglePause()
    {
        canvas2.enabled = !canvas2.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        if (canvas2.enabled)
            GM.instance.pauseTimer();
        else
            GM.instance.resumeTimer();
    }

    public void LevelChange(bool menu)
    {
        GM.instance.loadNextLevel(menu);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

}
