using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SacherSolutions.Attributes
{
    public class HideIfAttribute : ConditionalAttribute
    {
        public HideIfAttribute(string propertyName, bool value = true) : base(propertyName, value) { }
        public HideIfAttribute(string propertyName, int value, bool inverse = false) : base(propertyName, value, inverse) { }
        public HideIfAttribute(string propertyName, float value, bool inverse = false) : base(propertyName, value, inverse) { }
        public HideIfAttribute(string propertyName, string value, bool inverse = false) : base(propertyName, value, inverse) { }
        public HideIfAttribute(string propertyName, Color value, bool inverse = false) : base(propertyName, value, inverse) { }
        public HideIfAttribute(string propertyName, Enum value, bool inverse = false) : base(propertyName, value, inverse) { }
        public HideIfAttribute(string propertyName, Vector2 value, bool inverse = false) : base(propertyName, value, inverse) { }
        public HideIfAttribute(string propertyName, Vector3 value, bool inverse = false) : base(propertyName, value, inverse) { }

#if UNITY_EDITOR
        public override Satisfaction IsSatisfied(SerializedObject obj)
        {
            return base.IsSatisfied(obj) switch {
                Satisfaction.Satisfied => Satisfaction.NotSatisfied,
                Satisfaction.NotSatisfied => Satisfaction.Satisfied,
                Satisfaction.Error => Satisfaction.Error,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
#endif
    }
}