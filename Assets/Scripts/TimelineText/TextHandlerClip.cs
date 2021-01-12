using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TimelineText
{
    [Serializable]
    public class TextHandlerClip : PlayableAsset, ITimelineClipAsset
    {
        public TextHandlerBehaviour template = new TextHandlerBehaviour();

        public ClipCaps clipCaps => ClipCaps.Blending;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<TextHandlerBehaviour>.Create(graph, template);
            TextHandlerBehaviour clone = playable.GetBehaviour();
            return playable;
        }
    }
}