using UnityEngine;
using System.Collections;

public class PaddleMovement : MonoBehaviour {



    public float paddleSpeed = 1f;


    private Vector3 playerPos = new Vector3(0, -9.5f, 0);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        /*
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);
        transform.position = playerPos;
         * */
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

        transform.Translate(0.1f * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);

	}
}
