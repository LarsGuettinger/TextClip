﻿using System;
using Sirenix.OdinInspector;
using UnityEditor;
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

        public bool HasFilledLine => lines.Length > 0 ? true : false;

        private void OnValidate()
        {
            lineSpeed = lineSpeed < 0 ? 0 : lineSpeed;
        }
    }
}