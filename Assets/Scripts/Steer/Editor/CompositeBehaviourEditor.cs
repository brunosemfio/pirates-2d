using Steer.Behaviours;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Steer.Editor
{
    [CustomEditor(typeof(CompositeBehaviour))]
    public class CompositeBehaviourEditor : UnityEditor.Editor
    {
        private SerializedProperty movements;

        private ReorderableList list;

        private void OnEnable()
        {
            movements = serializedObject.FindProperty("movements");

            list = new ReorderableList(serializedObject, movements, true, true, true, true)
            {
                drawHeaderCallback = DrawHeader,
                drawElementCallback = DrawListItems,
            };
        }

        private void DrawHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "Movements");
        }

        private void DrawListItems(Rect rect, int index, bool isActive, bool isFocused)
        {
            var element = list.serializedProperty.GetArrayElementAtIndex(index);

            var behaviour = element.FindPropertyRelative("behaviour");

            var weight = element.FindPropertyRelative("weight");

            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width * .8f, EditorGUIUtility.singleLineHeight),
                behaviour, GUIContent.none);

            EditorGUI.PropertyField(
                new Rect(rect.x + rect.width * .85f, rect.y, rect.width * .15f, EditorGUIUtility.singleLineHeight),
                weight, GUIContent.none);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            list.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }
    }
}