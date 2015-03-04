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

    public GameObject soundLevel2;
    public GameObject sound2Level2;
    public GameObject sound3Level3;


    void awake()
    {
        //source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter (Collision other)
    {
        System.Random r = new System.Random();
        int random = r.Next(1, 4);


        switch (GM.instance.getCurrentLevel())
        {
            case 1:
                switch (random)
                {
                    case 1: GameObject.Instantiate(sound); break;
                    case 2: GameObject.Instantiate(sound2); break;
                    case 3: GameObject.Instantiate(sound2); break;
                    default: GameObject.Instantiate(sound); break;
                }
                break;
            case 2:
                switch (random)
                {
                    case 1: GameObject.Instantiate(soundLevel2); break;
                    case 2: GameObject.Instantiate(sound2Level2); break;
                    case 3: GameObject.Instantiate(sound3Level3); break;
                    default: GameObject.Instantiate(soundLevel2); break;
                }
                break;
            default: break;
        }


        GM.instance.DestroyBrick();
        Destroy(gameObject); 
    }   


}