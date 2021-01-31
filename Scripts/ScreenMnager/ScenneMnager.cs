using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenneMnager : MonoBehaviour
{
    [SerializeField] private Image FadeOutImage;

    [SerializeField] private float fadeOutDuration;
    [SerializeField] private float fadeAlphaRation;
    [SerializeField] public int sceeninDEX;

    public bool canFade = false;

    private Color color;

    private void Start()
    {
        color = new Color(FadeOutImage.color.r, FadeOutImage.color.g, FadeOutImage.color.b, 0);
    }

    private void FixedUpdate()
    {
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
