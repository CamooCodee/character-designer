using System;
using UnityEngine;

namespace SacherSolutions.Attributes
{
    public class DisableIfAttribute : HideIfAttribute
    {
        public DisableIfAttribute(string propertyName, bool value = true) : base(propertyName, value)
        {
        }

        public DisableIfAttribute(string propertyName, int value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public DisableIfAttribute(string propertyName, float value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public DisableIfAttribute(string propertyName, string value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public DisableIfAttribute(string propertyName, Color value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public DisableIfAttribute(string propertyName, Enum value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public DisableIfAttribute(string propertyName, Vector2 value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }

        public DisableIfAttribute(string propertyName, Vector3 value, bool inverse = false) : base(propertyName, value,
            inverse)
        {
        }
    }
}