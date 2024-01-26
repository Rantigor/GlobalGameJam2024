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
        StartCoroutine(DeleteEvent());
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        audienceEvent.EventEnter();
        Destroy(gameObject);
    }

    IEnumerator DeleteEvent()
    {
        yield return new WaitForSecondsRealtime(Random.Range(3,5));
        Destroy(gameObject);
    }
}
