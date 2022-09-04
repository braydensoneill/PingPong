using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private enum Direction {Left = 0, Right = 1}

    public GameObject player;
    public GameObject enemy;
    public GameObject wallUpper;
    public GameObject wallLower;
    public CharacterScore playerScoreScript;
    public CharacterScore enemyScoreScript;

    private float currentDirection;
    [SerializeField] private float initialSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float speedIncreasePerTick;

    [SerializeField] private float currentAngle;
    private float colliderPositionZ;
    private float ballPositionZ;

    public GameObject newBall;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private float timer;
    private float deathTimer;

    // Start is called before the first frame update
    void Start()
    {
        playerScoreScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterScore>();
        enemyScoreScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CharacterScore>();

        InitialiseBall();
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseSpeed(speedIncreasePerTick);

        //SpawnBallEveryXSeconds(2.5f);
        //DestroyBallAfterXSeconds(5);
    }

    private void SpawnBallEveryXSeconds(float time)
    {
        timer += Time.deltaTime;

        if (timer > time)
        {
            Instantiate(newBall, initialPosition, initialRotation);
            timer = 0;
        }
    }

    private void DestroyBallAfterXSeconds(float time)
    {
        deathTimer += Time.deltaTime;

        if (deathTimer > time)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void ChangeRotationOnCollision(Collider other)
    {
        colliderPositionZ = other.gameObject.transform.position.z;
        ballPositionZ = gameObject.transform.position.z;

        float reboundAngle = colliderPositionZ - ballPositionZ;

        if (other.gameObject.tag == "Player")
            currentAngle = reboundAngle;

        if (other.gameObject.tag == "Enemy")
            currentAngle = -reboundAngle;

        if (other.gameObject.tag == "WallUpper")
            currentAngle *= -1;

        if (other.gameObject.tag == "WallLower")
            currentAngle *= -1;

        RotateBall();
    }

    private void Movement()
    {
        if (currentDirection == (int)Direction.Left)
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        else if (currentDirection == (int)Direction.Right)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void RotateBall()
    {
        float rotationStrength = 30;
        transform.rotation = Quaternion.Euler(0, currentAngle * rotationStrength, 0);
    }

    private void InitialiseBall()
    {
        gameObject.name = "Ball";               // Change name of a new ball to avoid trails of "(Clone)" in name
        speed = initialSpeed;                   // Reset the speed to the initial speed 
        currentAngle = 0;
        currentDirection = Random.Range(0, 2);  // Return a avalue of either 0 or 1
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
        {
            currentDirection = (int)Direction.Right;
            ChangeRotationOnCollision(other);
        }

        if (other.gameObject.tag == "Enemy")
        {
            currentDirection = (int)Direction.Left;
            ChangeRotationOnCollision(other);
        }

        if (other.gameObject.tag == "WallUpper")
        {
            ChangeRotationOnCollision(other);
        }

        if (other.gameObject.tag == "WallLower")
        {
            ChangeRotationOnCollision(other);
        }

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
