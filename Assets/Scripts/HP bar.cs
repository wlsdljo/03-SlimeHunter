using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    [SerializeField] private Image barImage;

    public void ChangeHpBarAmount(float amount)
    {
        barImage.fillAmount = amount;
    }
}
