using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private bool _dead;

    private SpawnManagerHuman _humanSpawner;
    private Counter _counterScript;

    Animator humanAnimator;
    private void Start()
    {
        _humanSpawner = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerHuman>();
        _counterScript = GameObject.Find("Game Manager").GetComponent<Counter>();
        humanAnimator = GetComponent<Animator>();
        _humanSpawner.GoRight = false;
        _dead = false;
    }
    private void Update()
    {

        if (_humanSpawner.GoRight)
        {
            MoveRight();
        }
        else if (!_humanSpawner.GoRight)
        {
            MoveLeft();
        }
        KillWhenExited();

    }
    void MoveRight() {
        if (!_dead)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            transform.localRotation = Quaternion.Euler(0, -90, 0);
        }
    }

    void MoveLeft(){
        if (!_dead)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Flower Pot"))
        {
            _counterScript.CountKilledHuman(); 
            Dead();
            Destroy(gameObject, 2);


        }
    }
    public void Dead()
    {
        _dead = true;
        humanAnimator.SetBool("Death_b", true);
        humanAnimator.SetInteger("DeathType_int", 1);
        _humanSpawner.SpawnHumans();
    }

    public void KillWhenExited()
    {
        if (transform.position.x < -5 || transform.position.x > 55)
        {
            Dead();
            Destroy(gameObject);
        }
    }
}
