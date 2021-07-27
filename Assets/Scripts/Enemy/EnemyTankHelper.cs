using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyTankHelper : MonoBehaviour
{
    public int Damage { get; set; }
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out DefenderHealth defenderHealth))
        {
            GetComponent<EnemyHealth>().Die();
            defenderHealth.TakeDamage(Damage);
        }
    }
}