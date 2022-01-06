using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _flowerPot;
    [SerializeField]
    private Transform[] _spawnPoints;
    [SerializeField]
    private List<int> _tempPointNums;

    [SerializeField]
    private int _maxPots;
    [SerializeField]
    private float _delay;

    private bool _isStart = false;

    private int _randomPointNum;


    private void Start()
    {
        SetPointsList();
        SpawnFlowerPots();
    }

    private void SetPointsList()
    {// adds as many numbers to temppointnums List as in spawnpoints array
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _tempPointNums.Add(i);
        }
    }

    void SpawnFlowerPots()
    {//numbers get shuffled everytime "SpawnNewPot" gets fired
        SuffleSpawnPointNumbers();

        if (!_isStart)
        {
            //spawns at start "maxPots" 
            for (int i = 0; i < _maxPots; i++)
            {
                Vector3 spawnAt = _spawnPoints[_tempPointNums[0]].position;
                //spawn them
                GameObject pot = Instantiate(_flowerPot, spawnAt, Quaternion.identity);
                PotNum potnum = _flowerPot.GetComponent<PotNum>();
                potnum.potNumber = _tempPointNums[0];
                _tempPointNums.RemoveAt(0);
                _isStart = true;
            }
        }//this is always gonna get spawned when SpawnNewPot gets fired 
        else
        {
            Vector3 spawnAt = _spawnPoints[_tempPointNums[0]].position;
            //spawn them
            GameObject pot = Instantiate(_flowerPot, spawnAt, Quaternion.identity);
            PotNum potnum = _flowerPot.GetComponent<PotNum>();
            potnum.potNumber = _tempPointNums[0];
            _tempPointNums.RemoveAt(0);
        }
    }
    //shuffles the numbers in the List
    private void SuffleSpawnPointNumbers()
    {
        for (int i = 0; i < _tempPointNums.Count; i++)
        {
            int temp = _tempPointNums[i];
            int randomIndex = Random.Range(i, _tempPointNums.Count);
            _tempPointNums[i] = _tempPointNums[randomIndex];
            _tempPointNums[randomIndex] = temp;
        }
    }
    public void SpawnNewPot(int oldPot)
    {
        //add the potnum to list
        _tempPointNums.Add(oldPot);
        //invoke the next single spawn
        Invoke(nameof(SpawnFlowerPots), _delay);
    }


}
