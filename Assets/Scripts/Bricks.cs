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
        //Instantiate(sound);

        System.Random r = new System.Random();
        int random = r.Next(1, 4);

        switch(random)
        {
            case 1: GameObject.Instantiate(sound); break;
            case 2: GameObject.Instantiate(sound2); break;
            case 3: GameObject.Instantiate(sound3); break;
            default: GameObject.Instantiate(sound); break;
        }
       
        //Object s1 = Instantiate(sound1, transform.position, Quaternion.identity);
        Debug.Log("FITTEHÆLVETTE");
        Debug.Log("OnCollisionEnter in Bricks.cs called");
        Debug.Log("post audio");
       
        //Instantiate(brickParticle, transform.position, Quaternion.identity);
        GM.instance.DestroyBrick();
        Destroy(gameObject); 
        //audio.PlayOneShot(sound1);

    }   


}