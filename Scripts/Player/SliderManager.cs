using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private Slider Energy;


    [SerializeField] private float m_MaxEnergy;
    [SerializeField] private float m_EneryMissed, m_EnergyAdded, m_CoolDownEnergy;
    [SerializeField] private Gradient m_Gradiant;
    [SerializeField] private Image m_EnergyFillImage;
    private float m_CurrentEnergy;

    private bool m_CanRegenerate = false;



    public bool CanShoot = true;


    private void Start()
    {
        Inisialisation();
    }
    private void Update()
    {
        SliderEvents();
        SliderCurrentValue();
        TakeEnergyOnHit();
        RegerateEnergy();
        LowerCoolDownTimer();
    }
    private void Inisialisation()
    {
        Energy.maxValue = m_MaxEnergy;
        m_CurrentEnergy = m_MaxEnergy;
    }
    private void SliderEvents()
    {
        CanShoot = CheckAbilityToShoot();
    }
    private void SliderCurrentValue()
    {
        Energy.value = m_CurrentEnergy;
        m_EnergyFillImage.color = m_Gradiant.Evaluate(Energy.normalizedValue);
    }

    private float m_CoolDownTimer;
    private void TakeEnergyOnHit()
    {
        if (Input.GetButton("Fire1") && m_CurrentEnergy >= 0)
        {
            m_CurrentEnergy -= m_EneryMissed;
            m_CanRegenerate = false;
            m_CanLowerCoolDown = false;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            m_CoolDownTimer = m_CoolDownEnergy;
            m_CanLowerCoolDown = true;
        }
    }
    private bool m_CanLowerCoolDown = false;
    private void LowerCoolDownTimer()
    {
        if (m_CanLowerCoolDown)
        {
            m_CoolDownTimer -= Time.deltaTime;
            if (m_CoolDownTimer <= 0)
            {
                m_CanRegenerate = true;
                m_CanLowerCoolDown = false;
            }
            else
                m_CanRegenerate = false;
        }
    }
    private void RegerateEnergy()
    {
        if (m_CanRegenerate && m_CurrentEnergy <= m_MaxEnergy)
        {
            m_CurrentEnergy += m_EnergyAdded;
        }
    }
    private bool CheckAbilityToShoot()
    {
        return m_CurrentEnergy > 1;
    }
    private IEnumerator CoolDownEnergy()
    {
        m_CanRegenerate = false;
        yield return new WaitForSeconds(m_CoolDownEnergy);
        m_CanRegenerate = true;
    }
}
