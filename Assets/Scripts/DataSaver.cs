using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public static DataSaver Instance;
    public int Money { get; private set; }
    public int BulletDamage { get; private set; }
    public int SpeedRotation { get; private set; }
    public int DefenderHealth { get; private set; }

    [SerializeField] private DataProgressCollection _dataProgressCollection;

    private void Awake ()
    {
        Instance = this;

    }

    private void ReadAllPlayerPrefs ()
    {
        BulletDamage = GetCulletValue (0, PlayerPrefsKeys.BULLET_DAMAGE_LEVEL.ToString ());
        SpeedRotation = GetCulletValue (1, PlayerPrefsKeys.SPEED_ROTATION_LEVEL.ToString ());
        DefenderHealth = GetCulletValue (2, PlayerPrefsKeys.DEFENDER_HEALTH_LEVEL.ToString ());
        Money = GetCurrentMoney (PlayerPrefsKeys.CURRENT_MONEY.ToString ());
    }

    private int GetCulletValue (int typeId, string playerPrefsKey)
    {
        int currentLevel = 1;
        if (PlayerPrefs.HasKey (playerPrefsKey))
        {
            currentLevel = PlayerPrefs.GetInt (playerPrefsKey);
        }
        return (int) (_dataProgressCollection.dataInfos[typeId].startValue +
            (currentLevel - 1) * _dataProgressCollection.dataInfos[typeId].stepValue);
    }

    private int GetCurrentMoney (string playerPrefsKey)
    {
        if (PlayerPrefs.HasKey (playerPrefsKey))
        {
            return PlayerPrefs.GetInt (playerPrefsKey);
        }
        return 0;
    }
}