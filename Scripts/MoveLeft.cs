using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float speed = 30;
    private GameManager _gameManager;
    private float leftBound = -5;

    public bool isFalledPot { get; set; } = false;

    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //GameOver 
        if (!_gameManager.gameOver && !isFalledPot)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound || transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

   
}
