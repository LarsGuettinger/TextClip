using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Timeline;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ClipTextSO))]
    public class ClipTextSOEditor : OdinEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("OpenEditorWindow"))
            {
                ClipTextSOInspector.ShowWindow();
            }
        }
    }
}