using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("金币UI")]
    public TextMeshProUGUI coinText;

    [Header("血条体力UI")]
    public Image healthBarFill;
    public Image staminaBarFill;

    public float maxPlayerHealth = 100f;
    public float maxPlayerStamina = 100f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateCoinUI(Coin.totalCoins);
    }


    public void UpdateCoinUI(int amount) { coinText.text = amount.ToString();}
    public void UpdateHealthUI(int amount)
    {
        if (healthBarFill != null) healthBarFill.fillAmount = (float)amount / maxPlayerHealth;
    }

    public void UpdateStaminaUI(float amount)
    {
        if (staminaBarFill != null) staminaBarFill.fillAmount = amount / maxPlayerStamina;
    }
}