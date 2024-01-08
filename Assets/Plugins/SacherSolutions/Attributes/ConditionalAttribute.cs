using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SacherSolutions.Attributes
{
    public abstract class ConditionalAttribute : PropertyAttribute
    {
        private string PropertyName { get; }
        private bool Inverse { get; }
        private object Value { get; }
        private ConditionalPropertyType PropertyType { get; }

        private ConditionalAttribute(string propertyName, object value, bool inverse, ConditionalPropertyType propertyType)
        {
            PropertyName = propertyName;
            Value = value;
            Inverse = inverse;
            PropertyType = propertyType;
        }

        protected ConditionalAttribute(string propertyName, bool value = true) 
            : this(propertyName, value, false, ConditionalPropertyType.Bool) { }

        protected ConditionalAttribute(string propertyName, int value, bool inverse = false)
            : this(propertyName, value, inverse, ConditionalPropertyType.Int) { }

        protected ConditionalAttribute(string propertyName, float value, bool inverse = false)
            : this(propertyName, value, inverse, ConditionalPropertyType.Float) { }

        protected ConditionalAttribute(string propertyName, string value, bool inverse = false)
            : this(propertyName, value, inverse, ConditionalPropertyType.String) { }

        protected ConditionalAttribute(string propertyName, Color value, bool inverse = false)
            : this(propertyName, value, inverse, ConditionalPropertyType.Color) { }

        protected ConditionalAttribute(string propertyName, Enum value, bool inverse = false)
            : this(propertyName, value, inverse, ConditionalPropertyType.Enum) { }

        protected ConditionalAttribute(string propertyName, Vector2 value, bool inverse = false)
            : this(propertyName, value, inverse, ConditionalPropertyType.Vector2) { }

        protected ConditionalAttribute(string propertyName, Vector3 value, bool inverse = false)
            : this(propertyName, value, inverse, ConditionalPropertyType.Vector3) { }
        
        # if UNITY_EDITOR
        public virtual Satisfaction IsSatisfied(SerializedObject obj)
        {
            var property = obj.FindProperty(PropertyName);
            if (property == null)
            {
                Debug.LogError($"Property {PropertyName} not found");
                return Satisfaction.Error;
            }
            
            object value = PropertyType switch
            {
                ConditionalPropertyType.Bool => property.boolValue,
                ConditionalPropertyType.Int => property.intValue,
                ConditionalPropertyType.Float => property.floatValue,
                ConditionalPropertyType.String => property.stringValue,
                ConditionalPropertyType.Color => property.colorValue,
                ConditionalPropertyType.Enum => property.enumValueIndex,
                ConditionalPropertyType.Vector2 => property.vector2Value,
                ConditionalPropertyType.Vector3 => property.vector3Value,
                _ => throw new ArgumentOutOfRangeException()
            };
            
            return Equals(value, Value) ^ Inverse ? Satisfaction.Satisfied : Satisfaction.NotSatisfied;
        }
        #endif

        public enum Satisfaction
        {
            Satisfied,
            NotSatisfied,
            Error
        }
    }

    public enum ConditionalPropertyType {
        Bool,
        Int,
        Float,
        String,
        Color,
        Enum,
        Vector2,
        Vector3
    }
}