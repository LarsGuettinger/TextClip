using System;
using Sirenix.OdinInspector;
using Timeline;
using UnityEngine.Playables;

namespace TimelineText
{
    [Serializable]
    public class TextHandlerBehaviour : PlayableBehaviour
    {
        [InlineEditor] public ClipTextSO clipTextSo;
        public double totalSpeed = 0;
        [ReadOnly] public bool isInQueue = false;

        public bool HasMessage => clipTextSo && clipTextSo.HasFilledLine;

        public string Line => clipTextSo.lines[0];

        public double Speed => clipTextSo.lineSpeed == 0 ? totalSpeed : clipTextSo.lineSpeed;
    }
}