using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

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
    private void Update()
    {
        if(!audienceEvent.StandUpShow.isShowContinue)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator DeleteEvent()
    {
        yield return new WaitForSecondsRealtime(Random.Range(3,5));
        Destroy(gameObject);
    }
}
