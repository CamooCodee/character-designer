using UnityEditor;
using UnityEngine.UIElements;

namespace SacherSolutions.Attributes.Drawers
{
    [CustomPropertyDrawer(typeof(EnableIfAttribute))]

    public class EnableIfAttributeDrawer : ConditionalAttributeDrawer<EnableIfAttribute>
    {
        protected override void SetEnabled(VisualElement property, bool value)
        {
            property.SetEnabled(value);
        }
    }

}