using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Load Game"))
        {
            Application.LoadLevel(1);
        }
        
    }
}
