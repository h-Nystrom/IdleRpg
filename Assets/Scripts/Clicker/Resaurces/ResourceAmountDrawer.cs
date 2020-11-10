#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Clicker.Resources {
    // TODO: Hint for exercise for property drawers
#if UNITY_EDITOR
    [CustomPropertyDrawer (typeof (ResourceAmount))]
    public class ResourceAmountDrawer : PropertyDrawer {
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginProperty (position, label, property);
            var resourceAmount = property.FindPropertyRelative ("resource");
            var amount = property.FindPropertyRelative ("amount");
            EditorGUI.LabelField (new Rect (position.x, position.y, EditorGUIUtility.labelWidth, position.height), label);
            var width = (position.width - EditorGUIUtility.labelWidth);
            EditorGUI.PropertyField (new Rect (position.x + EditorGUIUtility.labelWidth, position.y, width * 0.3f, position.height), amount, GUIContent.none);
            EditorGUI.PropertyField (new Rect (position.x + EditorGUIUtility.labelWidth + width * 0.3f, position.y, width * 0.7f, position.height), resourceAmount, GUIContent.none);
            EditorGUI.EndProperty ();
        }
    }
#endif 
}