using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct Dialogues
{
    public TextDialogues[] dialogues;
}

[Serializable]
public struct TextDialogues
{
    public int id;
    public string name;
    public string color;
    public string dialogue;
    public string path;
    public bool continuer;
}
