using UnityEngine;
using System.Collections;
using System;

public class Bricks : MonoBehaviour {

    //public GameObject brickParticle;
  //  public AudioClip sound1;
   // public AudioSource source;
    public GameObject sound;
    public GameObject sound2;
    public GameObject sound3;


    void awake()
    {
        //source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter (Collision other)
    {
        Debug.Log("OnCollisionEnter in Bricks.cs called");

        System.Random r = new System.Random();
        int random = r.Next(1, 4);

        switch(random)
        {
            case 1: GameObject.Instantiate(sound); break;
            case 2: GameObject.Instantiate(sound2); break;
            case 3: GameObject.Instantiate(sound2); break;
            default: GameObject.Instantiate(sound); break;
        }

        GM.instance.DestroyBrick();
        Destroy(gameObject); 
    }   


}