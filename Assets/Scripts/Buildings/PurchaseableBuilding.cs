using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PurchaseableBuilding : MonoBehaviour
{
    public FloatSO availableBuildingLevel;
    public float buildingInteractionLevel;
    public FloatSO moneySO;
    public GameObject locker, arrow, purchase, moneyPrefab;
    public GameObject buildingRef;
    public TextMeshPro DisplayText;
    public Rigidbody playerRB;
    private bool stopRoutine;
    public bool isBuyed;
    public float buildingCurrentLevel, buildingMaxLevel, BuyPrice, UpgradePrice, CurrentPayment;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && availableBuildingLevel.Value >= buildingInteractionLevel)
        {
            if (moneySO.Value > 0 && playerRB.velocity.magnitude < 0.1)
            {
                StartCoroutine(PayMoney(moneySO, other));

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

    private void Start()
    {
        VisualDisplayChange();
    }

    void VisualDisplayChange()
    {
        if (availableBuildingLevel.Value >= buildingInteractionLevel)
        {
            if (!isBuyed)
            {
                purchase.gameObject.SetActive(true);
                locker.gameObject.SetActive(false);
                arrow.gameObject.SetActive(false);
                DisplayText.text = CurrentPayment + " / " + BuyPrice;
            }
            else
            {
                purchase.gameObject.SetActive(false);
                locker.gameObject.SetActive(false);
                arrow.gameObject.SetActive(true);
                DisplayText.text = CurrentPayment + " / " + (BuyPrice + buildingCurrentLevel * UpgradePrice);
            }

        }
        else
        {
            purchase.gameObject.SetActive(false);
            locker.gameObject.SetActive(true);
            arrow.gameObject.SetActive(false);
            DisplayText.text = "LOCKED";
        }
    }
    void MaxLevel()
    {
        purchase.gameObject.SetActive(false);
        locker.gameObject.SetActive(false);
        arrow.gameObject.SetActive(false);
        DisplayText.text = "MAX LEVEL";
    }


    IEnumerator PayMoney(FloatSO moneySO, Collider other)
    {
        if (!stopRoutine && buildingCurrentLevel < buildingMaxLevel)
        {
            stopRoutine = true;
            for (int i = (int)moneySO.Value; i > -1; i--)
            {
                if (i! <= 0)
                {
                    moneySO.ChangeAmountBy(-1);
                    GameObject moneyObj = Instantiate(moneyPrefab, this.gameObject.transform.parent);
                    moneyObj.GetComponent<SphereCollider>().enabled = false;
                    moneyObj.transform.position = other.transform.position;
                    moneyObj.transform.DOJump(buildingRef.transform.position, 3, 1, 0.3f);
                    moneyObj.GetComponent<ICollectable>().playSound();
                    Destroy(moneyObj.gameObject, 2f);
                    CurrentPayment++;
                    BuildingBuyCheck();
                    yield return new WaitForSecondsRealtime(0.1f);
                }
                if (!stopRoutine)
                {
                    yield break;
                }
            }
            stopRoutine = false;
        }
       
    }

    void BuildingBuyCheck()
    {
        if (!isBuyed)
        {
            if (CurrentPayment >= BuyPrice)
            {
                CurrentPayment = 0;
                isBuyed = true;
                buildingCurrentLevel++;
                availableBuildingLevel.ChangeAmountBy(1);
                VisualDisplayChange();
            }
        }
        else if (isBuyed && buildingCurrentLevel < buildingMaxLevel)
        {
            if (CurrentPayment >= BuyPrice + UpgradePrice * buildingCurrentLevel)
            {
                buildingCurrentLevel++;
                CurrentPayment = 0;
              
            }
        }
        DisplayTextUpdate();
    }

    void DisplayTextUpdate()
    {
        if (!isBuyed)
        {
            DisplayText.text = CurrentPayment + " / " + BuyPrice;
        }
        else if(buildingCurrentLevel<buildingMaxLevel)
        {
            DisplayText.text = CurrentPayment + " / " + (BuyPrice + buildingCurrentLevel * UpgradePrice);
        }
        else
        {
            MaxLevel();
        }

    }

}
