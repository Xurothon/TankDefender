using UnityEngine;

public class BulletDamager : MonoBehaviour
{
    public int Damage { get; set; }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.GetComponent<EnemyHealth> () != null)
        {
            other.gameObject.GetComponent<EnemyHealth> ().TakeDamege (Damage);
            Destroy (gameObject);
        }
    }
}