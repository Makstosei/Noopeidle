using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Rigidbody playerRB;
    Animator playerAnimator;
    PlayerInteractionManager playerInteractionManager;
    PlayerController playerController;
    public GameObject playerAxe, playerPickaxe;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerInteractionManager = GetComponent<PlayerInteractionManager>();
        playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (playerRB.velocity.magnitude >= 0.01)
        {
            playerAnimator.SetFloat("Speed", playerRB.velocity.magnitude);
        }
        else
        {
            playerAnimator.SetFloat("Speed", 0);
        }

       
    }



   

}
