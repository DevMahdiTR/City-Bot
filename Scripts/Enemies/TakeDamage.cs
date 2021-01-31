using System.Collections;
using System.Collections.Generic;
using PoolingSystem;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private int m_BulletDamge;
    [SerializeField] private float m_Health;
    [SerializeField] private GameObject m_BloodEffect;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip audioClip;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Bullet"))
        {
            GoodPoolingSystem.Instance.AddToPool("Bullet_1",other.gameObject);
            DmageHit();
        }
    }
    private void DmageHit()
    {

        audio.PlayOneShot(audioClip,0.25f);
        m_Health -= m_BulletDamge; 

        print(m_Health);
        if (m_Health <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        Instantiate(m_BloodEffect,transform.position,transform.rotation);
        Destroy(gameObject);
    }

}
