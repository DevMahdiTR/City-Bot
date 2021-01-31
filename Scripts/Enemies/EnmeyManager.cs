using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmeyManager : MonoBehaviour
{
    [SerializeField] private MoveToPlayer moveToPlayer;
    [SerializeField] private NormalEnemyMovement  normalEnemyMovement;


    private void BackToNormalMoving()
    {
        normalEnemyMovement.enabled = true;
        moveToPlayer.enabled = false;
    }
    private void FindPlayerAndRunToit()
    {
        normalEnemyMovement.enabled = false;
        moveToPlayer.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            FindPlayerAndRunToit();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            BackToNormalMoving();
     }
}
