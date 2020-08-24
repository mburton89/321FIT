using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Color", menuName = "Selectable Colors")]
public class SelectableColor : ScriptableObject
{
    public string colorName;
    [Range(0f, 1f)]
    public float hue;
    [Range(0f, 1f)]
    public float satruatrion;
    [Range(0f, 1f)]
    public float scanlines;
}
