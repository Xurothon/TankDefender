using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MyIntEvent : UnityEngine.Events.UnityEvent<int> { }

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private int _startHealth;
    [SerializeField] private Image _healthImage;
    [SerializeField] private Color _goodHealth;
    [SerializeField] private Color _normalHealth;
    [SerializeField] private Color _badHealth;
    private int _health;
    private int _cost;
    public UnityEngine.Events.UnityEvent OnDestroy;
    public MyIntEvent OnDestroyFromBullet;

    public void TakeDamege (int damage)
    {
        _health -= damage;
        if (_health > 0) ChangeHealthImage (_health);
        else DieFromBullet ();
    }

    public void Die ()
    {
        OnDestroy.Invoke ();
        OnDestroy.RemoveAllListeners ();
        Destroy (gameObject);
    }

    private void DieFromBullet ()
    {
        OnDestroyFromBullet.Invoke (_cost);
        OnDestroyFromBullet.RemoveAllListeners ();
        Die ();
    }

    public void SetCost (int cost)
    {
        _cost = cost;
    }

    private void Awake ()
    {
        _health = _startHealth;
        _healthImage.fillAmount = 1;
        _healthImage.color = _goodHealth;
    }

    private void ChangeHealthImage (int health)
    {
        _healthImage.fillAmount = (float) _health / _startHealth;
        if (health < 65)
        {
            if (health > 30) _healthImage.color = _normalHealth;
            else _healthImage.color = _badHealth;
        }
    }
}