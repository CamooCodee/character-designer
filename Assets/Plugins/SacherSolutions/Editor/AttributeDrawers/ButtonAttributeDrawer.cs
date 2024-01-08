using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;


namespace SacherSolutions.Attributes.Drawers
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class ButtonAttributeDrawer : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            InspectorElement.FillDefaultInspector(root, serializedObject, this);

            var targetType = target.GetType();
            var methods = targetType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes(typeof(ButtonAttribute), true);
                if (!attributes.Any())
                    continue;

                if (method.GetParameters().Length > 0)
                {
                    Debug.LogError("Cannot use ButtonAttribute on method with parameters");
                    continue;
                }

                var buttonAttribute = (ButtonAttribute)attributes[0];
                var button = new Button(() => method.Invoke(target, null))
                {
                    text = string.IsNullOrWhiteSpace(buttonAttribute.label) ? method.Name : buttonAttribute.label
                };
                root.Add(button);
            }

            return root;
        }
    }
}
