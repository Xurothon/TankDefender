using UnityEngine;

[RequireComponent (typeof (EnemyHealth))]
public class EnemyTankHelper : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private int _cost;
    [SerializeField] private EnemyHealth _enemyHealth;

    private void Awake ()
    {
        _cost = (int) Random.Range (1f, 3f);
        _enemyHealth = GetComponent<EnemyHealth> ();
        _enemyHealth.SetCost (_cost);
    }

    private void FixedUpdate ()
    {
        transform.position = Vector3.MoveTowards (transform.position, Vector3.zero, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.GetComponent<DefenderHealth> () != null)
        {
            _enemyHealth.Die ();
            other.gameObject.GetComponent<DefenderHealth> ().TakeDamage (10);
        }
    }
}