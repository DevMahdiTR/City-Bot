using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    [SerializeField] private Rigidbody2D m_Rigidbody;
    [SerializeField] private float m_PlayerSpeed;


    private Vector2 m_Movement;
    private Vector2 m_MousePosition;



    private void Update()
    {
        GetPlayerInput();
    }
    private void FixedUpdate()
    {
       
    }
    public void MovePlayer()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement.normalized * m_PlayerSpeed * Time.fixedDeltaTime);
    }
    public void RotatePlayer()
    {
        var dir = m_MousePosition - m_Rigidbody.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        m_Rigidbody.rotation = angle;
    }

    private void GetPlayerInput()
    {
        m_Movement.x = Input.GetAxisRaw("Horizontal");
        m_Movement.y = Input.GetAxisRaw("Vertical");
        m_MousePosition = m_Camera.ScreenToWorldPoint(Input.mousePosition);
    }

}

