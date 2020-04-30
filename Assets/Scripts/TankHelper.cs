using UnityEngine;
using UnityEngine.EventSystems;

public class TankHelper : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private EventTrigger eventTrigger;

    [Header ("Bullet Settings")]
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletLifeTime;
    [SerializeField] private Transform _spawnBulletPosition;
    [SerializeField] private Transform _bulletTarget;
    [SerializeField] private GameObject _bullet;

    private void Awake ()
    {
        EventTrigger.Entry entry = new EventTrigger.Entry ();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener ((data) => ChangeDirection ((PointerEventData) data));
        eventTrigger.triggers.Add (entry);
    }

    private void FixedUpdate ()
    {
        transform.Rotate (Vector3.forward, _speed * Time.deltaTime);
    }

    private void ChangeDirection (PointerEventData data)
    {
        _speed *= -1f;
        Shoot ();
    }

    private void Shoot ()
    {
        GameObject bullet = Instantiate (_bullet);
        bullet.transform.position = _spawnBulletPosition.transform.position;
        bullet.transform.rotation = transform.rotation;
        Vector3 direction = _bulletTarget.position - Vector3.zero;
        bullet.GetComponent<Rigidbody2D> ().AddForce (direction.normalized * _bulletSpeed, ForceMode2D.Impulse);
        Destroy (bullet, _bulletLifeTime);
    }
}