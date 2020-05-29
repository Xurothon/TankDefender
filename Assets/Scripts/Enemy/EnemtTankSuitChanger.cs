using UnityEngine;

[RequireComponent (typeof (EnemyTankHelper))]
public class EnemtTankSuitChanger : MonoBehaviour
{
    [SerializeField] private EnemyTankSuitCollection _enemyTankSuitCollection;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private SpriteRenderer _body;
    [SerializeField] private SpriteRenderer _barrel;

    private void Awake ()
    {
        _enemyHealth = GetComponent<EnemyHealth> ();
        int bodyId = Random.Range (0, _enemyTankSuitCollection.enemyTankSuits.Length);
        int barrelId = Random.Range (0, _enemyTankSuitCollection.barrel.Length);
        _body.sprite = _enemyTankSuitCollection.enemyTankSuits[bodyId].body;
        GetComponent<EnemyTankHelper> ().Damage = _enemyTankSuitCollection.enemyTankSuits[bodyId].damage;
        _enemyHealth.SetHealthValue (_enemyTankSuitCollection.enemyTankSuits[bodyId].health);
        _enemyHealth.SetCost (_enemyTankSuitCollection.enemyTankSuits[bodyId].cost);
        _barrel.sprite = _enemyTankSuitCollection.barrel[barrelId];
        Destroy (this);
    }
}