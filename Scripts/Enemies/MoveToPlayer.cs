using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] private NavMeshAgent2D navMeshAgent;
    [SerializeField] private Transform m_PlayerPosition;

    private void FixedUpdate()
    {
        navMeshAgent.destination =(m_PlayerPosition.position);
        RotateObject();
    }

    [SerializeField] private Rigidbody2D m_Rigidbody;
    [SerializeField] private Camera camera;
    [SerializeField] float smooth = 0.3f;
    float yVelocity = 0.0f;
    private void RotateObject()
    {
        var dir = (Vector2)m_PlayerPosition.position - m_Rigidbody.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
         m_Rigidbody.rotation = Mathf.SmoothDampAngle(m_Rigidbody.rotation,angle,ref yVelocity,smooth);
    }
}
