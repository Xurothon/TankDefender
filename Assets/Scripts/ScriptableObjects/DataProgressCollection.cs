using UnityEngine;

[CreateAssetMenu (fileName = "DataProgressCollection", menuName = "MakeDataProgressCollection", order = 101)]
public class DataProgressCollection : ScriptableObject
{
    public DataInfo[] dataInfos;
}