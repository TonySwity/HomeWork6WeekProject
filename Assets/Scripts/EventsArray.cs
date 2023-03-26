using UnityEngine;
using UnityEngine.Events;

public class EventsArray : MonoBehaviour
{
    public UnityEvent[] ThisEvents;

    public void StartEvent(int eventIndex)
    {
        ThisEvents[eventIndex].Invoke();
    }
}
