using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinsAvailable", menuName = "ScriptableObjects/CoinsAvailable", order = 2)]
public class CoinsAvailable : ScriptableObject,ISerializationCallbackReceiver
{
    public string NameType;
    public float AvailableCount;

    [System.NonSerialized]
    public float RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = AvailableCount;
    }

    public void OnBeforeSerialize() { }

}
