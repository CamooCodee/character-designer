using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(ReadonlyAttribute))]
public class ReadOnlyPropertyDrawer : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var field = new PropertyField(property);
        field.SetEnabled(false);
        return field;
    }
}