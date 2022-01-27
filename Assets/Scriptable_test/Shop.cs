using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shop", menuName = "ScriptableObjects/Shop", order = 1)]
public class Shop : ScriptableObject,ISerializationCallbackReceiver
{
	public string NameType;
	public float Count;
	public bool Status;

	[System.NonSerialized]
	public bool RuntimeStatus;

	public void OnAfterDeserialize()
	{
		RuntimeStatus = Status;
	}

	public void OnBeforeSerialize() { }
}
