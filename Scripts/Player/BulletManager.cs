using System.Collections;
using System.Collections.Generic;
using PoolingSystem;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_Rigidbody;

    [SerializeField] private float m_BulletSpeed;

    [SerializeField] private float m_RecoilRation;

    private Transform firePoint_0, firePoint_1;

    private void Awake()
    {
        firePoint_0 = GameObject.FindGameObjectWithTag("FirePoint_0").GetComponent<Transform>();
        firePoint_1 = GameObject.FindGameObjectWithTag("FirePoint_1").GetComponent<Transform>();
    }


    private void OnEnable()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            m_Rigidbody.AddForce(Recoil(firePoint_0) * m_BulletSpeed, ForceMode2D.Impulse);
            transform.position = firePoint_0.position;
            transform.rotation = firePoint_0.rotation;
        }
        else
        {
            m_Rigidbody.AddForce(Recoil(firePoint_1) * m_BulletSpeed, ForceMode2D.Impulse);
            transform.position = firePoint_1.position;

            transform.rotation = firePoint_1.rotation;
        }
    }

    private Vector3 Recoil(Transform currenRotation)
    {
        var newDirection = new Vector3(Random.Range(currenRotation.up.x - m_RecoilRation, currenRotation.up.x + m_RecoilRation), currenRotation.up.y, currenRotation.up.z);
        return newDirection;
    }
    [SerializeField] private GameObject m_BulletEffect;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            GoodPoolingSystem.Instance.AddToPool("Bullet_1",gameObject);
            Instantiate(m_BulletEffect,transform.position,transform.rotation);
        }
    }
}
