using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Money : MonoBehaviour, ICollectable
{
    public CollectableSO collectableSORef;
    public FloatSO moneySO;

  

    private void OnTriggerEnter(Collider other)
    {
        Interact(other);
    }

    public void Interact(Collider other)
    {
        if (other.tag == "Player")
        {
            var collectableObjectController = other.GetComponent<CollectableObjectController>();
            if (!collectableObjectController.collectedItems.Contains(this.gameObject) && collectableObjectController.collectedItems.Count < collectableObjectController.MaxStackAmount)
            {
                collectableObjectController.collectedItems.Add(this.gameObject);
                gameObject.transform.parent = collectableObjectController.collectedPositionRef.transform;
                gameObject.transform.DOLocalJump(new Vector3(0, collectableObjectController.collectedItems.Count * 0.22f, 0), 2, 1, 0.2f);
                gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
                GetComponent<SphereCollider>().enabled = false;
                playSound();
                StartCoroutine(stopTrail());
            }
        }
       
    }


    IEnumerator stopTrail()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        GetComponent<TrailRenderer>().enabled = false;
    }

    public float returnMoney()
    {
        return collectableSORef.CollectAmount;
    }

    public void playSound()
    {
        if (collectableSORef.soundManagerSO.isSoundOn)
        {
            collectableSORef.soundManagerSO.audioSource.PlayOneShot(collectableSORef.collectSound);
        }
    }
}
