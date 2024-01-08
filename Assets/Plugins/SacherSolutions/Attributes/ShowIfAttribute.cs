using System;
using UnityEngine;

namespace SacherSolutions.Attributes
{
    public class ShowIfAttribute : ConditionalAttribute
    {
        public ShowIfAttribute(string propertyName, bool value = true) : base(propertyName, value)
        {
        }

        public ShowIfAttribute(string propertyName, int value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public ShowIfAttribute(string propertyName, float value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public ShowIfAttribute(string propertyName, string value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public ShowIfAttribute(string propertyName, Color value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public ShowIfAttribute(string propertyName, Enum value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public ShowIfAttribute(string propertyName, Vector2 value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public ShowIfAttribute(string propertyName, Vector3 value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }
    }
}