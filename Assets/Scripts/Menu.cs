using UnityEngine;
using System.Collections;

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
        if (muteToggle == false)
        {
            AudioListener.volume = 1;
        }
        
        
        
    }

   




}
