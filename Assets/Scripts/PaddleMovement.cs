﻿using UnityEngine;
using System.Collections;


public class PaddleMovement : MonoBehaviour {

    

    public float paddleSpeed = 0.1f;


    private Vector3 playerPos = new Vector3(0, -2f, 0);

    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, -5.7f, 5.7f), -4f, 0f);
        transform.position = playerPos;
    }

    void OnCollisionEnter(Collision col)
    {
/*
        Vector3 PO = col.other.transform.position;
        Vector3 NO = new Vector3(0, 1, 0);
        Vector3 NO_PO_Scaled = Vector3.Scale(NO, PO);
        NO_PO_Scaled = Vector3.Scale(NO_PO_Scaled, new Vector3(2, 2, 2));
        NO_PO_Scaled = Vector3.Scale(NO_PO_Scaled, NO);
        Vector3 OQ = PO - NO_PO_Scaled;
        
        col.other.rigidbody.AddForceAtPosition(new Vector3(650f, 0, 0), OQ);     
 * 
 * */
        GM.instance.BricksHitInARow = 0;
        GM.instance.HitCount++;
        int hits = GM.instance.HitCount;
        float force = 300f;
        if(hits < 4)
        {
            force = 300f;
        }
        else if(hits >= 4 && hits <= 11)
        {
            force = 350f;
        }
        else if(hits >= 12)
        {
            force = 400f;
        }
        
        /*foreach (ContactPoint contact in col.contacts)
        {
            if (contact.thisCollider == collider)
            {
                float z = contact.point.x - transform.position.x;
                contact.otherCollider.rigidbody.AddForce(force, 0, 0);
            }
        }*/
    }
    /*

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
         /*
 

        transform.Translate(0.1f * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
        
	}
    */
}
