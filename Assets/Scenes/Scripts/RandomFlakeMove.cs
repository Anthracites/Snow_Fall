using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlakeMove : MonoBehaviour
{
    public float speed = 0.1f;
    public Camera targetCamera;
    public GameObject BoomPref;
    public GameObject inst_obj;
 

    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector2.up * speed);
        if (transform.position.y < -15)
        {
            Destroy(gameObject);
            Debug.Log("Flake destroyed");
        }
    }

    void OnMouseEnter()
    {
        Vector3 SpawnPosition = gameObject.transform.position;
        Destroy(gameObject);
        (GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>().Score_player)++;
        Quaternion spawnRotation = Quaternion.identity;
        inst_obj = Instantiate(BoomPref, SpawnPosition, spawnRotation) as GameObject;
        Debug.Log("Flake destroyed");
    }

    public void ChangeSpeedFlakes()
    {
        speed = speed + 0.1f;
        Debug.Log("Speed of flake move changed");
    }
}
