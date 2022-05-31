using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Collectable",menuName ="ScriptableObjects/Collectable")]
public class CollectableSO : ScriptableObject
{
    public AudioClip collectSound;
    public int CollectAmount;
    public SoundManagerSO soundManagerSO;
}
