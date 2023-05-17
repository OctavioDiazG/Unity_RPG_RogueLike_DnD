using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralDungeonGeneratorMaker : MonoBehaviour
{
    public List<GameObject> levelPrefavs;
    public GameObject bossLevelPrefav;
    void Start()
    {
        int firstlevel = RandomNumber();
        levelPrefavs[firstlevel].transform.position = transform.position;
        levelPrefavs[firstlevel].transform.parent = transform;
        levelPrefavs.Remove(levelPrefavs[firstlevel]);
    }

    int RandomNumber()
    {
        int randomNumber = Random.Range(0, levelPrefavs.Count);
        return randomNumber;
    }
}
