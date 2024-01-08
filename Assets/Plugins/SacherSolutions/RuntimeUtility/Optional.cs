using System;
using UnityEngine;

/// <summary>
/// Serializable struct that  represents an optional value.
/// </summary>
[Serializable]
public struct Optional<T> {
    [SerializeField] bool _enabled;
    [SerializeField] T _value;
    
    public Optional(T initialValue, bool enabled = true) {
        _enabled = enabled;
        _value = initialValue;
    }

    /// <summary>
    /// Whether or not the value is present.
    /// </summary>
    public bool Enabled => _enabled;
    
    /// <summary>
    /// The value, if present.
    /// </summary>
    public T Value => _value;
    
    public void If(Action<T> action) {
        if (_enabled) {
            action(_value);
        }
    }
}