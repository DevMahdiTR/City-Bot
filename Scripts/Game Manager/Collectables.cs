using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private GamerManager1 gameManager;
    [SerializeField] private GameObject lightEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.UpdateText(1);
            Instantiate(lightEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
