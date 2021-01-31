using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAttack playerAttack;

    private void Awake()
    {

    }
    private void Start()
    {

    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        playerMovement.MovePlayer();
        playerMovement.RotatePlayer();
        playerAttack.PlayerShoot();
    }

}
