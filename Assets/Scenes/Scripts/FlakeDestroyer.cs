using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakeDestroyer : MonoBehaviour //class for destroy snow flake 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
