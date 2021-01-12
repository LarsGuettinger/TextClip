#if UNITY_EDITOR

using UnityEditor.Timeline;
using UnityEngine.Timeline;

namespace TimelineText
{
    [CustomTimelineEditor(typeof(TextHandlerClip))]
    public class TextHandlerClipEditor : ClipEditor
    {
        public override void OnClipChanged(TimelineClip clip)
        {
            var myClip = (TextHandlerClip) clip.asset;
        
            string nameString;
            if (!myClip.template.HasMessage)
            {
                nameString = "Empty Message";
            }
            else if (myClip.template.Line.Length > 30)
            {
                nameString = myClip.template.Line.Substring(0, 30);
            }
            else
            {
                nameString = myClip.template.Line;
            }

            myClip.template.totalSpeed = clip.duration;
            clip.displayName = nameString;
            base.OnClipChanged(clip);
        }
    }
}
#endif