using UnityEngine;
using UnityEngine.Playables;

namespace TimelineText
{
    public class TextHandlerMixerBehaviour : PlayableBehaviour
    {
        private SubTitleHandler texthandler;

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            texthandler = playerData as SubTitleHandler;

            if (texthandler == null) return;

            int inputCount = playable.GetInputCount();

            for (int i = 0; i < inputCount; i++)
            {
                ScriptPlayable<TextHandlerBehaviour> inputPlayable =
                    (ScriptPlayable<TextHandlerBehaviour>) playable.GetInput(i);
                TextHandlerBehaviour input = inputPlayable.GetBehaviour();
                if (!input.isInQueue && playable.GetInputWeight(i) > float.Epsilon)
                {
                    texthandler.NextInQueue(input.clipTextSo, input.Speed);
                    if (Application.isPlaying) input.isInQueue = true;
                }
            }
        }
    }
}