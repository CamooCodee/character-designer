using System;
using UnityEngine;

namespace SacherSolutions.Attributes
{
    public class EnableIfAttribute : ConditionalAttribute
    {
        public EnableIfAttribute(string propertyName, bool value = true) : base(propertyName, value)
        {
        }

        public EnableIfAttribute(string propertyName, int value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public EnableIfAttribute(string propertyName, float value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public EnableIfAttribute(string propertyName, string value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public EnableIfAttribute(string propertyName, Color value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public EnableIfAttribute(string propertyName, Enum value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public EnableIfAttribute(string propertyName, Vector2 value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public EnableIfAttribute(string propertyName, Vector3 value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }
    }
}