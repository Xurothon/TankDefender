using UnityEngine;

[CreateAssetMenu (fileName = "EnemyTankSuitCollection", menuName = "MakeEnemyTankSuitCollection", order = 101)]
public class EnemyTankSuitCollection : ScriptableObject
{
    public EnemyTankSuit[] enemyTankSuits;
    public Sprite[] barrel;

}