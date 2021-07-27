using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MyIntEvent : UnityEngine.Events.UnityEvent<int> { }

public class EnemyHealth : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent OnDestroy;
    public MyIntEvent OnDestroyFromBullet;
    [SerializeField] private Image _healthImage;
    [SerializeField] private Gradient _gradient;
    private int _startHealth;
    private int _health;
    private int _cost;


    public void TakeDamege(int damage)
    {
        _health -= damage;
        if (_health > 0) ChangeHealthImage(_health);
        else DieFromBullet();
    }

    public void Die()
    {
        OnDestroy.Invoke();
        OnDestroy.RemoveAllListeners();
        Destroy(gameObject);
    }

    private void DieFromBullet()
    {
        OnDestroyFromBullet.Invoke(_cost);
        OnDestroyFromBullet.RemoveAllListeners();
        Die();
    }

    public void SetCost(int cost)
    {
        _cost = cost;
    }

    public void SetHealthValue(int health)
    {
        _startHealth = health;
        _health = _startHealth;
        _healthImage.fillAmount = 1;
        _healthImage.color = _gradient.Evaluate(1);
    }

    private void ChangeHealthImage(int health)
    {
        float healthPercentage = (float)_health / _startHealth;
        _healthImage.fillAmount = healthPercentage;
        _healthImage.color = _gradient.Evaluate(healthPercentage);
    }
}