using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "woodsword")]
public class Scriptable : ScriptableObject
{
    // Start is called before the first frame update
    public string ObjectName;
    public Sprite sprite;
    public enum ItemType
    {
        WEAPON
    }
    public ItemType itemType;
}
