using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private enum Direction {Left = 0, Right = 1}

    public GameObject newBall;
    public CharacterScore playerScoreScript;
    public CharacterScore enemyScoreScript;

    private float currentDirection;
    [SerializeField] private float initialSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float speedIncreasePerTick;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        playerScoreScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterScore>();
        enemyScoreScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CharacterScore>();

        gameObject.name = "Ball";               // Change name of a new ball to avoid trails of "(Clone)" in name
        speed = initialSpeed;                   // Reset the speed to the initial speed 
        currentDirection = Random.Range(0, 2);  // Return a avalue of either 0 or 1
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseSpeed(speedIncreasePerTick);

        if (currentDirection == (int)Direction.Left)
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        else if (currentDirection == (int)Direction.Right)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void ResetBall()
    {
        initialPosition = Vector3.zero;
        initialRotation = Quaternion.Euler(Vector3.zero);
    }

    private void IncreaseSpeed(float amount)
    {
        speed += amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            currentDirection = (int)Direction.Right;

        if (other.gameObject.tag == "Enemy")
            currentDirection = (int)Direction.Left;

        if (other.gameObject.tag == "GoalPlayer")
        {
            enemyScoreScript.AddScore(1);
            Instantiate(newBall, initialPosition, initialRotation);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "GoalEnemy")
        {
            playerScoreScript.AddScore(1);
            Instantiate(newBall, initialPosition, initialRotation);
            Destroy(gameObject);
        }
    }
}
