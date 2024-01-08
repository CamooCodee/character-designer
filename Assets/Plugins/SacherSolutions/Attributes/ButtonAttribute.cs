using System;

namespace SacherSolutions.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ButtonAttribute : Attribute
    {
        public readonly string label;

        public ButtonAttribute(string label = "")
        {
            this.label = label;
        }
    }

}