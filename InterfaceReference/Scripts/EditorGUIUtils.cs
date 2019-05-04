/*
 *  Author: Alessandro Salani (Cippman)
 */

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

namespace CippSharpEditor.Interfaces
{
    public static class EditorGUIUtils
    {
        /// <summary>
        /// It draws the property only if its different from null.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="property"></param>
        /// <param name="label"></param>
        public static void DrawProperty(Rect rect, SerializedProperty property, GUIContent label)
        {
            if (property != null)
            {
                EditorGUI.PropertyField(rect, property, label, property.hasChildren);
            }
        }
        
        /// <summary>
        /// It draws the property only if its different from null.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="property"></param>
        /// <param name="label"></param>
        public static void DrawNotEditableProperty(Rect rect, SerializedProperty property, GUIContent label)
        {
            bool guiEnabled = GUI.enabled;
            GUI.enabled = false;
            if (property != null)
            {
                EditorGUI.PropertyField(rect, property, label, property.hasChildren);
            }
            GUI.enabled = guiEnabled;
        }
    }
}
#endif
