using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGeneration : MonoBehaviour
{
    public GameObject moneyRef;
    public GameObject generatePoint;
    private bool isSpawned;
    private PurchaseableBuilding purchaseableBuildingRef;
    [SerializeField]
    private int xLenght, yLenght, zLenght;
    public int x, y, z;
    public List<GameObject> GeneratedMoneys;
    private bool canGenerate;

    private void Awake()
    {
        purchaseableBuildingRef = GetComponent<PurchaseableBuilding>();
    }

    private void LateUpdate()
    {
        if (purchaseableBuildingRef.isBuyed)
        {
            canGenerate = true;
            StartCoroutine(Generate());
        }

    }



    IEnumerator Generate()
    {
        if (!isSpawned)
        {
            isSpawned = true;
            if (GeneratedMoneys.Count + 1 > xLenght * zLenght * yLenght)
            {
                canGenerate = false;

            }

            if (canGenerate)
            {
                var tempMoney = Instantiate(moneyRef, generatePoint.transform);
                tempMoney.transform.localPosition = Vector3.zero;
                GeneratedMoneys.Add(tempMoney);
                if (GeneratedMoneys.Count % xLenght == 0)
                {
                    x = xLenght;
                }
                else
                {
                    if (GeneratedMoneys.Count % xLenght == 1 && GeneratedMoneys.Count > xLenght)
                    {
                        z++;
                        if (z >= zLenght)
                        {
                            z = 0;
                        }
                    }
                    x = GeneratedMoneys.Count % xLenght;
                }

                if (GeneratedMoneys.Count > (xLenght * zLenght) && GeneratedMoneys.Count % (xLenght * zLenght) == 1)
                {
                    y++;
                }
                tempMoney.transform.localPosition = new Vector3(1 + -1 * x, +0.4f * y, -0.5f * z);
                yield return new WaitForSecondsRealtime(1f);
            }

            isSpawned = false;
        }

    }

}
