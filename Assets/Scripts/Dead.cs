using UnityEngine;
using System.Collections;

public class Dead : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        GM.instance.LoseLife();
    }
}