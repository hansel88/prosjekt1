using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

    public GameObject brickParticle;

    void OnCollisionEnter (Collision other)
    {
        Debug.Log("OnCollisionEnter in Bicks.cs called");
        //Instantiate(brickParticle, transform.position, Quaternion.identity);
        GM.instance.DestroyBrick();
        Destroy(gameObject);
    }
}