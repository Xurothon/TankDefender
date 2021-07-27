using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefenderHealth : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private float _flashSpeed = 5f;
    [SerializeField] private Image _damageImage;
    [SerializeField] private Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    private int _health;
    private const int _startHealth = 100;
    private bool _isGetDamage;
    private bool _isDead;

    public void TakeDamage(int amount)
    {
        _isGetDamage = true;
        _health -= amount;
        _healthSlider.value = _health;
        if (_health <= 0 && !_isDead)
        {
            Death();
        }
    }

    private void Death()
    {
        _isDead = true;
        SceneManager.LoadScene(0);
    }

    private void FixedUpdate()
    {
        if (_isGetDamage)
        {
            _damageImage.color = flashColor;
            _isGetDamage = false;
        }
        else
        {
            _damageImage.color = Color.Lerp(_damageImage.color, Color.clear, _flashSpeed * Time.deltaTime);
        }
    }

    void Awake()
    {
        _health = _startHealth;
        _healthSlider.value = _health;
    }
}