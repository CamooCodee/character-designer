using UnityEditor;
using UnityEngine.UIElements;

namespace SacherSolutions.Attributes.Drawers
{
    [CustomPropertyDrawer(typeof(DisableIfAttribute))]

    public class DisableIfAttributeDrawer : ConditionalAttributeDrawer<DisableIfAttribute>
    {
        protected override void SetEnabled(VisualElement property, bool value)
        {
            property.SetEnabled(value);
        }
    }

}