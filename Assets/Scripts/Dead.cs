using UnityEngine;
using System.Collections;



public class Dead : MonoBehaviour
{
    public GameObject sound;
    void OnTriggerEnter(Collider col)
    {
        GM.instance.LoseLife();
        GameObject.Instantiate(sound);
    }
}