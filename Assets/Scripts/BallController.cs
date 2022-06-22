using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private enum Direction {Left = 0, Right = 1}

    public GameObject newBall;
    public PlayerScore playerScoreScript;
    public PlayerScore enemyScoreScript;

    private float currentDirection;
    [SerializeField] private float speed;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        currentDirection = Random.Range(0, 2);  // Return a avalue of either 0 or 1

        playerScoreScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        enemyScoreScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
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
