using TMPro;
using UnityEngine;

public class CoinsChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    private int _coins;

    private void Awake ()
    {
        _coinsText.text = _coins.ToString ();
    }

    public void ChangeCoinsText (int cost)
    {
        _coins += cost;
        _coinsText.text = _coins.ToString ();
    }
}