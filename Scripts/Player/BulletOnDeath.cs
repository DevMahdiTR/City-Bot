using System.Collections;
using System.Collections.Generic;
using PoolingSystem;
using UnityEngine;

public class BulletOnDeath : MonoBehaviour
{
    [SerializeField] private float m_BulletLifeTime;
    [SerializeField] private string m_BulletTag;

    [SerializeField] private float m_DamageOnHit;
    private float m_CurrentLifeTime;


    private void Update()
    {
        BulletLife();
    }
    private void BulletLife()
    {
        if (m_CurrentLifeTime <= 0)
        {
            GoodPoolingSystem.Instance.AddToPool(m_BulletTag, gameObject);
        }
        else
            m_CurrentLifeTime -= Time.deltaTime;
    }
    private void OnEnable()
    {
        m_CurrentLifeTime = m_BulletLifeTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
            GoodPoolingSystem.Instance.AddToPool(m_BulletTag, gameObject);
        if (other.CompareTag("Enemy"))
        {
            GoodPoolingSystem.Instance.AddToPool(m_BulletTag, gameObject);
        }

    }
}
