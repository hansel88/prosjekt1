using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour 
{


   public bool muteToggle = false;

    public void ChangeToScene(int sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
    
    public void MuteGame(){

        if (muteToggle == true)
        {
            AudioListener.volume = 0;
        }
   
    }


}
