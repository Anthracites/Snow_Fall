using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakeSpawn: MonoBehaviour //Спавн "снежинок"
{
    public Vector3 spawnvalues;
    public GameObject Flake;
    public GameObject RandomFlake;
    public GameObject ObjScoreCounte;
    public Sprite Flakes;
    public float Size;
    public float Speed;
    public bool IsFall = true;
    private GameObject inst_obj;
    public GameObject FlakePref;
    public float j = 1;
    public int i = 0;
    public int FlakeAmount;

    public void Start()
    {
        StartCreatePref();
        StartCoroutine(SpawnFlakes());

    }

    void StartCreatePref()
    {
        FlakePref = Instantiate(Flake);
        FlakePref.transform.position = new Vector3(0, 50, -1);
        FlakePref.GetComponent<SpriteRenderer>().sprite = Flakes;
        FlakePref.AddComponent<PolygonCollider2D>();
        FlakePref.GetComponent<PolygonCollider2D>().usedByComposite = true;
        FlakePref.GetComponent<FlakeMoveFocus>().ScoreCounterObj = ObjScoreCounte;
        FlakePref.GetComponent<FlakeMoveFocus>().speed = Speed;
        FlakePref.transform.localScale = new Vector3(Size, Size, Size);
        Debug.Log("Start pref crated");
    }

    public void ChangeCollider()
    {
        Destroy(FlakePref);
        StartCreatePref();
        Debug.Log("Pref changed");
    }


    private IEnumerator SpawnFlakes()

        {
        while (true)
        {
            Vector3 SpawnPosition = new Vector3(Random.Range(-spawnvalues.x, spawnvalues.x), (spawnvalues.y), (spawnvalues.z));
            Quaternion spawnRotation = Quaternion.identity;
            inst_obj = Instantiate(FlakePref, SpawnPosition, spawnRotation) as GameObject;
            inst_obj.GetComponent<FlakeMoveFocus>().enabled = true;
            FlakePref.transform.parent = gameObject.transform;
            Debug.Log("Flake created");
            yield return new WaitForSeconds(1 / j);
        }
    }

}
