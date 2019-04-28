using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MiniGame
{
    public string Name;
    public string SceneName;
    public string Description;

    public MiniGame (string name, string scene, string desc, int bank) {
        Name = name;
        SceneName = scene;
        Description = desc;
    }
}
