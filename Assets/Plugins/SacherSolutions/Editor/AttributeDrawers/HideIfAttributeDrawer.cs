using UnityEditor;
using UnityEngine.UIElements;

namespace SacherSolutions.Attributes.Drawers
{
    [CustomPropertyDrawer(typeof(HideIfAttribute))]

    public class HideIfAttributeDrawer : ConditionalAttributeDrawer<HideIfAttribute>
    {
        protected override void SetEnabled(VisualElement property, bool value)
        {
            property.style.display = value ? DisplayStyle.Flex : DisplayStyle.None;
        }
    }

}