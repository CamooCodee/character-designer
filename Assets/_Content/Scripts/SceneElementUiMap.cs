using System;
using UnityEngine;

public class SceneElementUiMap : MonoBehaviour
{
    [SerializeField] private MapEntry[] map;

    private void Awake() => 
        Map();

    private void Map()
    {
        foreach (var entry in map)
        {
            foreach (var c in entry.controller)
            {
                c.Initialize(entry.element);
            }
        }
    }
}

[Serializable]
public class MapEntry
{
    public SceneElement element;
    public SceneElementButtonController[] controller;
}