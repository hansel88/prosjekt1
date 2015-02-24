using UnityEngine;
using System.Collections;

public class PaddleMovement : MonoBehaviour {


    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("LEFT!");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("RIGHT!");
        }
         */

        transform.Translate(1f * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);

	}
}
