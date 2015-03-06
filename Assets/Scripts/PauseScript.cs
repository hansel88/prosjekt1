using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

    public Canvas canvas;

    void Start()
    {
        canvas.enabled = false;
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
        canvas.enabled = !canvas.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        if (canvas.enabled)
            GM.instance.pauseTimer();
        else
            GM.instance.resumeTimer();
    }

    public void RestartLevel()
    {
        GM.instance.getCurrentLevel();
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
