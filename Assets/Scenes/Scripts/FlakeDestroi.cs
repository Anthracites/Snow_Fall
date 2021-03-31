using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakeDestroi : MonoBehaviour // Class for destroy exploz
{
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5)
        {
            Destroy(gameObject);
        }
        else
        { }
    }
}
