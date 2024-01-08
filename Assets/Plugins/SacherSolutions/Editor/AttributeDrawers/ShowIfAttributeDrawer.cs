using UnityEditor;
using UnityEngine.UIElements;

namespace SacherSolutions.Attributes.Drawers
{
    [CustomPropertyDrawer(typeof(ShowIfAttribute))]

    public class ShowIfAttributeDrawer : ConditionalAttributeDrawer<ShowIfAttribute>
    {
        protected override void SetEnabled(VisualElement property, bool value)
        {
            property.style.display = value ? DisplayStyle.Flex : DisplayStyle.None;
        }
    }

}