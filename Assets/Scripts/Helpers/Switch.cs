using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Helpers
{
    public class Switch : MonoBehaviour
    {
        [field : SerializeField]
        public bool StateSwitch { get; private set; }

        [SerializeField] private UnityEvent OnSwitchOn;
        [SerializeField] private UnityEvent OnSwitchOff;

        public void SetSwitch()
        {
            StateSwitch = !StateSwitch;

            if (StateSwitch) OnSwitchOn?.Invoke();
            else OnSwitchOff?.Invoke();
        }
    }
}
