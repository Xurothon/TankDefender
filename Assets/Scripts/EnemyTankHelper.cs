using UnityEngine;

public class EnemyTankHelper : MonoBehaviour
{

    [SerializeField] private float _speed;
    public UnityEngine.Events.UnityEvent OnDestroy;

    private void FixedUpdate ()
    {
        transform.position = Vector3.MoveTowards (transform.position, Vector3.zero, _speed * Time.deltaTime);
    }

    private void Die ()
    {
        OnDestroy.Invoke ();
        OnDestroy.RemoveAllListeners ();
        Destroy (gameObject);
    }

    private void OnTriggerEnter2D (Collider2D other)
    {

    }
    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.GetComponent<TankHelper> () != null)
        {
            Die ();
        }
        else if (other.gameObject.GetComponent<Rigidbody2D> () != null)
        {
            Die ();
            Destroy (other.gameObject);
        }
    }
}