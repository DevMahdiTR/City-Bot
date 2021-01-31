using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent2D navMeshAgent;
    [SerializeField] private float xMax, xMin, yMax, yMin;
    [SerializeField] private float timeToChangeDirection;


    private float timer;
    private Vector2 randomPositonVector;
    

    private void Start()
    {
       MovePlayer();
    }
    private void FixedUpdate()
    {
        ChangePositionByTimer();
        RotateObject();
    }
    private void ChangePositionByTimer()
    {
        if(timer<=0)
        {
            MovePlayer();
            timer = timeToChangeDirection;
        }
        else
            timer-= Time.deltaTime;
    }
    private void MovePlayer()
    {
        randomPositonVector = RandomPosition();
        navMeshAgent.destination = randomPositonVector;
        
    }

    private Vector2 RandomPosition()
    {
        var randomX = Random.Range(xMin, xMax);
        var randomY = Random.Range(yMin, yMax);
        return new Vector2(randomX, randomY);
    }
    [SerializeField] private Rigidbody2D m_Rigidbody;
    [SerializeField] private Camera camera;

    [SerializeField] float smooth = 0.3f;
    float yVelocity = 0.0f;
    private void RotateObject()
    {
        var dir = randomPositonVector - m_Rigidbody.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        m_Rigidbody.rotation = Mathf.SmoothDampAngle(m_Rigidbody.rotation,angle,ref yVelocity,smooth);
    }
}
