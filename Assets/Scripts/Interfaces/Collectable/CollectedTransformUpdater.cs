using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedTransformUpdater : MonoBehaviour
{
   public GameObject collectedpositionUpdater;
    public GameObject player;
    void Update()
    {
        gameObject.transform.position = collectedpositionUpdater.transform.position;
        gameObject.transform.rotation = player.transform.rotation;
    }
}
