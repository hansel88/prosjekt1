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
            Pause();
            Screen.showCursor = true;
        }
    }

    public void Pause()
    {
        canvas.enabled = !canvas.enabled;
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
