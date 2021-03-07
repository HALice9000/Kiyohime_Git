using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class s_dialogue
{
    public Sprite[] charaPics;
    public string[] names;

    [TextArea(5, 10)]
    public string[] sentences;
}
