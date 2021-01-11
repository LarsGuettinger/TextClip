using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Timeline
{
    [CreateAssetMenu(fileName = "defaultText", menuName = "SO/Timeline/Text", order = 0)]
    public class ClipTextSO : ScriptableObject
    {
        public string speakerName = "";
        public string[] lines = new[] {""};

        [Tooltip("Amount of Time (in sec) till one line appears completely")]
        public float lineSpeed = 0;

        public Color color = Color.white;

        private void OnValidate()
        {
            lineSpeed = lineSpeed < 0 ? 0 : lineSpeed;
        }
    }
}