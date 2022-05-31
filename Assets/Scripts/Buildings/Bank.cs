using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bank : MonoBehaviour
{
    public GameObject buildingRef;
    private bool isSellingStarted;
    private bool stopRoutine;
    public FloatSO moneySO;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            var collectedItems = other.GetComponent<CollectableObjectController>().collectedItems;
            var playerRB = other.GetComponent<Rigidbody>();
            if (collectedItems.Count > 0 && playerRB.velocity.magnitude < 0.1)
            {
                StartCoroutine(SellItems(collectedItems, other));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            stopRoutine = false;
        }
    }

    IEnumerator SellItems(List<GameObject> collectedItems, Collider other)
    {
        if (!stopRoutine)
        {
            stopRoutine = true;
            for (int i = collectedItems.Count - 1; i > -1; i--)
            {
                if (collectedItems[i] != null)
                {
                    moneySO.ChangeAmountBy(collectedItems[i].GetComponent<ICollectable>().returnMoney());
                    collectedItems[i].GetComponent<ICollectable>().playSound();
                    collectedItems[i].transform.parent = buildingRef.transform;
                    collectedItems[i].transform.DOJump(buildingRef.transform.position, 3, 1, 0.3f);
                    Destroy(collectedItems[i].gameObject, 1f);
                    yield return new WaitForSecondsRealtime(0.1f);
                    collectedItems.RemoveAt(i);
                }
                if (!stopRoutine)
                {
                    yield break;
                }
            }
            stopRoutine = false;
        }
    }
}
