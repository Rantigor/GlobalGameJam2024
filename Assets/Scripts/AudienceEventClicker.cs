using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AudienceEventClicker : MonoBehaviour, IPointerClickHandler
{
    AudienceEvent audienceEvent;
    private void Start()
    {
        audienceEvent = FindObjectOfType<AudienceEvent>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        audienceEvent.EventEnter();
    }
}
