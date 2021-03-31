using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakeMoveFocus : MonoBehaviour// Class for snow flake move down
{
    public float speed;
    public Camera targetCamera;
    public GameObject ScoreCounterObj;
    public GameObject BoomPref;
    public GameObject inst_obj;
    public bool IsRandom = false;

    void Update()
    {
        MoveDown();
    }

    void OnMouseEnter()
    {
        Vector3 SpawnPosition = gameObject.transform.position;
        Destroy(gameObject);
        ScoreCounterObj.GetComponent<ScoreCounter>().Score_player++;
        Quaternion spawnRotation = Quaternion.identity;
        inst_obj = Instantiate(BoomPref, SpawnPosition, spawnRotation) as GameObject;
        Debug.Log("Flake destroyed");
    }

    public void ChangeSpeedFlakes()
    {
        speed = speed + 0.1f;
        Debug.Log("Speed changed");
    }

    void MoveDown()
    {
        transform.Translate(-Vector2.up * speed);
    }
}
