using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    public FloatSO moneySO;
    public TextMeshProUGUI moneyText;

    private void Update()
    {
        moneyText.text = moneySO.Value.ToString();
    }
}
