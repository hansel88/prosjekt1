using UnityEngine;
using System.Collections;



public class Dead : MonoBehaviour
{
    public GameObject sound;
    void OnTriggerEnter(Collider col)
    {
        GameObject.Instantiate(sound);
        GM.instance.LoseLife();
    }
}