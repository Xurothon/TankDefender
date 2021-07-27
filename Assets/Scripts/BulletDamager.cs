using UnityEngine;

public class BulletDamager : MonoBehaviour
{
    public int Damage { get; set; }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamege(Damage);
            Destroy(gameObject);
        }
    }
}