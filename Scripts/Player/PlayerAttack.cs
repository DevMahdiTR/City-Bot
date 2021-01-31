using System.Collections;
using System.Collections.Generic;
using PoolingSystem;
using UnityEngine.UI;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject m_Light;
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private AudioClip soundShoot;
    [SerializeField] private Camera m_Camera;
    [SerializeField] private Rigidbody2D m_Rigidbody;
    [SerializeField] private GoodPoolingSystem poolingSystem;
    [SerializeField] private SliderManager sliderManager;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private Transform[] m_FirePoint;
    [SerializeField] private GameObject m_Bullet;
    [SerializeField] private float m_BulletSpeed;
    [SerializeField] private float m_ShootingRatio;
    [SerializeField] private float m_RecoilRation;
    [SerializeField] private float m_KnockBackPower;
    [SerializeField] private float m_KnockBackDuration;

    [SerializeField] private string m_BulletTags;
    [SerializeField] private float m_CameraShakeRatio;
    [SerializeField] private float m_CameraShakeTime;
    private bool m_ShootIsPressed = false;

    private float m_TimerCounter = 0;

    private Vector2 m_MousePosition;

    private void Update()
    { 
        KeepTrackOnHealth();
         GetPlayerInput();
    }

    private GameObject m_CurrentBullet;
    public void PlayerShoot()
    {
        if (sliderManager.CanShoot)
        {
            if (m_TimerCounter <= 0)
            {
                if (m_ShootIsPressed)
                {
                    EffectOnAttack();
                    m_Animator.SetBool("Shoot_Trigger", true);
                    m_CurrentBullet = poolingSystem.GetOutOfPool(m_BulletTags);
                    m_CurrentBullet = poolingSystem.GetOutOfPool(m_BulletTags);
                    m_CurrentBullet = poolingSystem.GetOutOfPool(m_BulletTags);

                    m_TimerCounter = m_ShootingRatio;

                }
            }
            else
            {
                m_TimerCounter -= Time.deltaTime;
            }
        }
    }

    private void EffectOnAttack()
    {
        StartCoroutine(KnockBack(m_KnockBackPower, m_KnockBackDuration, m_MousePosition));
        CinemachineShake.Instance.ShakeCamera(m_CameraShakeRatio, m_CameraShakeTime);
        shootSound.PlayOneShot(soundShoot);
        if (m_Light.activeInHierarchy)
        {
            m_Light.SetActive(false);
        }
    }
    private void GetPlayerInput()
    {
        OnDeath();
        m_ShootIsPressed = Input.GetButton("Fire1");
        if (!m_ShootIsPressed || !sliderManager.CanShoot)
        {
            do
            {
                m_Animator.SetBool("Shoot_Trigger", false);

            } while (1 == 2);
        }
        m_MousePosition = m_Camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonUp("Fire1"))
        {
            m_Light.SetActive(true);
        }
    }

    private IEnumerator KnockBack(float knockBackDuration, float knockBackPower, Vector3 position)
    {
        float timer = 0f;


        while (knockBackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (position - transform.position).normalized;
            m_Rigidbody.AddForce(-direction * knockBackPower);
        }
        yield return 0;
    }
    private Vector3 Recoil(Transform currenRotation)
    {
        var newDirection = new Vector3(Random.Range(currenRotation.up.x - m_RecoilRation, currenRotation.up.x + m_RecoilRation), currenRotation.up.y, currenRotation.up.z);
        return newDirection;
    }
    [SerializeField] private float PlayerHealth;
    [SerializeField] private float damagePerHit;
    [SerializeField] private Slider PlayerHealthBar;
    [SerializeField] private Gradient m_Gradiant;
    [SerializeField] private Image m_EnergyFillImage;
    [SerializeField] private float power,dure,Am1,Am2;

    private void KeepTrackOnHealth()
    {
        PlayerHealthBar.value = PlayerHealth;
        m_EnergyFillImage.color = m_Gradiant.Evaluate(PlayerHealthBar.normalizedValue);
    }
    [SerializeField] private EnergyMnager Fade;
    private void OnDeath()
    {
        if(PlayerHealth<=0)
        {
            Fade.sceeninDEX = 1;
            Fade.canFade  = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemiess"))
        {
            StartCoroutine(KnockBack(power, dure, other.transform.position));
            CinemachineShake.Instance.ShakeCamera(m_CameraShakeRatio*Am1, m_CameraShakeTime*Am2);
            PlayerHealth -= damagePerHit;
        }
    }

}
