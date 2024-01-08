using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace SacherSolutions.Attributes.Drawers
{
    public abstract class ConditionalAttributeDrawer<T> : PropertyDrawer where T : ConditionalAttribute
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var conditionalAttribute = (T)attribute;
            var field = new PropertyField(property);
        
            field.TrackSerializedObjectValue(property.serializedObject, UpdateField);
            UpdateField(property.serializedObject);
        
            return field;
        
            void UpdateField(SerializedObject obj)
            {
                var satisfaction = conditionalAttribute.IsSatisfied(obj);
                SetEnabled(field, satisfaction == ConditionalAttribute.Satisfaction.Satisfied);
            }
        }
    
        protected abstract void SetEnabled(VisualElement property, bool value);
    }
   
}