using UnityEngine;

[RequireComponent (typeof (EnemyHealth))]
public class EnemyTankHelper : MonoBehaviour
{

    [SerializeField] private float _speed;
    public int Damage { get; set; }

    private void FixedUpdate ()
    {
        transform.position = Vector3.MoveTowards (transform.position, Vector3.zero, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.GetComponent<DefenderHealth> () != null)
        {
            GetComponent<EnemyHealth> ().Die ();
            other.gameObject.GetComponent<DefenderHealth> ().TakeDamage (Damage);
        }
    }
}