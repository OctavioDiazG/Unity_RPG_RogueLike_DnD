using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallNextRoom : MonoBehaviour
{
    bool isColiding = false;
    public GameObject dungeonGenerator;
    public ProceduralDungeonGeneratorMaker proceduralDungeonGeneratorMaker;
    public Transform nextRoomPosition;

    void Start() 
    {
        proceduralDungeonGeneratorMaker = dungeonGenerator.GetComponent<ProceduralDungeonGeneratorMaker>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isColiding)
        {
            int firstlevel = RandomNumber();
            proceduralDungeonGeneratorMaker.levelPrefavs[firstlevel].transform.position = nextRoomPosition.position;
            proceduralDungeonGeneratorMaker.levelPrefavs[firstlevel].transform.parent = nextRoomPosition;
            proceduralDungeonGeneratorMaker.levelPrefavs.Remove(proceduralDungeonGeneratorMaker.levelPrefavs[firstlevel]);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            isColiding = true;
            Debug.Log("a");
        }
    }

    private void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            isColiding = false;
        }
    }

    int RandomNumber()
    {
        int randomNumber = Random.Range(0, proceduralDungeonGeneratorMaker.levelPrefavs.Count);
        return randomNumber;
    }
}
