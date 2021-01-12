using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TimelineText
{
    [TrackColor(49, 77, 121)]
    [TrackClipType(typeof(TextHandlerClip))]
    [TrackBindingType(typeof(SubTitleHandler))]
    public class TextHandlerTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<TextHandlerMixerBehaviour>.Create(graph, inputCount);
        }
    }
}