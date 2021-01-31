using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class EnergyMnager : MonoBehaviour
{
    [SerializeField] private Slider enerygySlider;

    [SerializeField] private float maxEnergy;


    [SerializeField] private float enrgyPerSec;

    private float currentEnergy;
    private int counter;
    private void Start()
    {
        currentEnergy = maxEnergy;
        enerygySlider.maxValue = maxEnergy;
         color = new Color(FadeOutImage.color.r, FadeOutImage.color.g, FadeOutImage.color.b, 0);
    }
    private void Update()
    {
        OnLostEnergy();
    }

    private void OnLostEnergy()
    {
        if (currentEnergy <= 0)
        {
            canFade = true;
        }
    }
    private void FixedUpdate()
    {
        currentEnergy -= enrgyPerSec;
        enerygySlider.value = currentEnergy;
        if (canFade)
        {
            FadeOutImage.color = color;
            color.a+=fadeAlphaRation;
        }
        if(color.a>=1)
        {
            StartCoroutine( load());
        }
    }
    [SerializeField] private Image FadeOutImage;

    [SerializeField] private float fadeOutDuration;
    [SerializeField] private float fadeAlphaRation;
    [SerializeField] public int sceeninDEX;

    public bool canFade = false;

    private Color color;
    public void Fade()
    {
        canFade = true;
        FadeOutImage.enabled = true;
    }
    public void Exit()
    {
        canFade = true;
        Application.Quit();
    }
    private IEnumerator load()
    {
        yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene(sceeninDEX);
    }

}
