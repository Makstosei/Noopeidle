using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip footstepLeft, footstepRight;
    public AudioSource audioSource;
    public List<AudioClip> WoodHitSounds, MineHitSounds;
    private PlayerInteractionManager playerInteractionManager;

    private void Start()
    {
        playerInteractionManager = GetComponent<PlayerInteractionManager>();
    }




    void LeftFootstep()
    {
        audioSource.PlayOneShot(footstepLeft);
    }

    void RightFootstep()
    {
        audioSource.PlayOneShot(footstepRight);
    }

 

}
