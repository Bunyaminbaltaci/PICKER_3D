using Extensions;
using Keys;
using UnityEngine.Events;

namespace Events
{
    public class InputEvents : MonoSingleton<InputEvents>
    {
        public UnityAction onFirstTimeTouchTaken = delegate { };
        public UnityAction onInputTaken = delegate { };
        public UnityAction<HorizontalInputParams> onInputDragged = delegate { };
        public UnityAction onInputReleased = delegate { };
    }
}