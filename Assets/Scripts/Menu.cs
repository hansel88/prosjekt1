using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    void OnGUI()
    {

        if(GUI.Button(new Rect(Screen.width / 3.2f, Screen.height / 2.6f, Screen.width / 2.8f, Screen.height / 4), ""));
        {
            Application.LoadLevel(1);
        }

        if(GUI.Button(new Rect(Screen.width / 3.2f, Screen.height / 1.6f, Screen.width / 2.8f, Screen.height / 4), ""));
        {
            Application.Quit();
        }
        
    }
}
