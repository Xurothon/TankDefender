using TMPro;
using UnityEngine;

public class CoinsChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    private int _coins;

    public void ChangeCoinsText(int cost)
    {
        _coins += cost;
        UpdateText();
    }

    private void UpdateText()
    {
        _coinsText.text = _coins.ToString();
    }

    private void Awake()
    {
        UpdateText();
    }
}