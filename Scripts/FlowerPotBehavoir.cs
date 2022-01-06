using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPotBehavoir : MonoBehaviour
{
    private Rigidbody _flowerPotRb;
    public bool _flowerPotFalling;
    public bool isGrounded = false;
    private PotNum _potNumScript;
    private SpawnManager _spawnManagerScript;


    public float fallMultiplier = 3.5f;

    private void Start()
    {

        _spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        _potNumScript = GetComponent<PotNum>();
        _flowerPotRb = GetComponent<Rigidbody>();
        _flowerPotFalling = false;
    }

    private void Update()
    {
        if (_flowerPotRb.velocity.y < 0)
        {
            _flowerPotRb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
        
    private void OnMouseDown()
    {
        _flowerPotFalling = _flowerPotRb.useGravity = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (_flowerPotFalling)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {// to do spawn new (oldPot num)
                _spawnManagerScript.SpawnNewPot(_potNumScript.potNumber);
                DestroyPot();
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                HumanBehaviour humanBehaviour = collision.gameObject.GetComponent<HumanBehaviour>();
                humanBehaviour.Dead();
            }
        }
        else
        {
            _spawnManagerScript.SpawnNewPot(_potNumScript.potNumber);
            DestroyPot();
        }
    }

    public void DestroyPot()
    {
        MoveLeft move = GetComponent<MoveLeft>();
        isGrounded = true;
        Destroy(gameObject);
    }
}
