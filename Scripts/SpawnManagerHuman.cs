using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerHuman : MonoBehaviour
{
    //spawn humans based on maxHumans
    //choose number from array "spawn points" when needs to spawn
    //
    //if spawnpoints[1] than direct character at left else...
    //when human dies, it fires spawnhuman function
    [SerializeField]
    private int _maxHumans;
    [SerializeField]
    private Vector3[] _spawnPoints;
    [SerializeField]
    private GameObject[] _humans;
    public bool GoRight;


    private void Start()
    {
        for (int i = 0; i < _maxHumans; i++)
        {
             SpawnHumans();
        }
    }

    public void SpawnHumans()
    {
        int RandomHumanIndex = Random.Range(0, _humans.Length);
        int randomSpawnInt = Random.Range(0, 2);

        if (randomSpawnInt == 0)
        {   
            GoRight = true;
            Instantiate(_humans[RandomHumanIndex], _spawnPoints[randomSpawnInt], Quaternion.Euler(0, 90, 0));
        }
        else if (randomSpawnInt == 1)
        {

            GoRight =  false;
            Instantiate(_humans[RandomHumanIndex], _spawnPoints[randomSpawnInt], Quaternion.Euler(0, -90, 0));
        }
    }

}
