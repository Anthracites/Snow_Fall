using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakeSpawn_Old: MonoBehaviour
{
    public Vector3 spawnvalues;
    public GameObject Flake;
    public GameObject RandomFlake;
    public GameObject ObjScoreCounte;
    public Sprite Flakes;
    public float timer;
    public bool IsFall = true;
    private GameObject inst_obj;
    public float j = 1;
    public int i = 0;
    public int FlakeAmount;

    void SpawnFlakes()
        
    {
        timer += Time.deltaTime;
        if (timer >= (1/j))
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(-spawnvalues.x, spawnvalues.x), (spawnvalues.y), (spawnvalues.z));
            Quaternion spawnRotation = Quaternion.identity;
            inst_obj = Instantiate(Flake, SpawnPosition, spawnRotation) as GameObject;
            inst_obj.GetComponent<SpriteRenderer>().sprite = Flakes;
            inst_obj.AddComponent<PolygonCollider2D>();
            inst_obj.GetComponent<PolygonCollider2D>().usedByComposite = true;
            inst_obj.GetComponent<FlakeMoveFocus>().ScoreCounterObj = ObjScoreCounte;
            timer = 0;
        }

        else
        { }
    }

    void SpawnRandomMove()
    {
        while (i < FlakeAmount)

        {
            Vector3 SpawnPosition = new Vector3(Random.Range(-spawnvalues.x, spawnvalues.x), Random.Range(-spawnvalues.y, spawnvalues.y), Random.Range(-spawnvalues.z, spawnvalues.z));
            Quaternion spawnRotation = Quaternion.identity;
            inst_obj = Instantiate(RandomFlake, SpawnPosition, spawnRotation) as GameObject;
            inst_obj.GetComponent<SpriteRenderer>().sprite = Flakes;
            inst_obj.name = ("Flake" + (i.ToString()));
            inst_obj.AddComponent<PolygonCollider2D>();
            inst_obj.GetComponent<PolygonCollider2D>().usedByComposite = true;
            inst_obj.GetComponent<FlakeMoveFocus>().ScoreCounterObj = ObjScoreCounte;

            i++;
        }
    }

    void Update()
    {
        if (IsFall == true)
        {
            SpawnFlakes();
        }
        else 
            if (IsFall == false)
        {
            SpawnRandomMove();
        }
    }
}

    


