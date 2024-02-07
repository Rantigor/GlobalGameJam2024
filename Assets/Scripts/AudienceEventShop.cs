using UnityEngine;

public class AudienceEventShop : MonoBehaviour
{
    private AudienceEvent _audienceEvent;

    private void Awake()
    {
        _audienceEvent = FindObjectOfType<AudienceEvent>();
    }
    private void Start()
    {
        _audienceEvent.EventRatio = PlayerPrefs.GetInt(nameof(_audienceEvent.EventRatio));
        _audienceEvent.EventTime = PlayerPrefs.GetInt(nameof(_audienceEvent.EventTime));
        _audienceEvent.EventEarn = PlayerPrefs.GetInt(nameof(_audienceEvent.EventEarn));
        _audienceEvent.EventChance = PlayerPrefs.GetInt(nameof(_audienceEvent.EventChance));
        _audienceEvent.EventNumber = PlayerPrefs.GetInt(nameof(_audienceEvent.EventNumber));
    }

    public void EventRatioIncrease()
    {
        _audienceEvent.EventRatio -= 1;
        PlayerPrefs.SetInt(nameof(_audienceEvent.EventRatio), _audienceEvent.EventRatio);
    }
    public void EventTimeIncrease()
    {
        _audienceEvent.EventTime += 1;
        PlayerPrefs.SetInt(nameof(_audienceEvent.EventTime), _audienceEvent.EventTime);
    }
    public void EventEarnIncrease()
    {
        _audienceEvent.EventEarn += 1;
        PlayerPrefs.SetInt(nameof(_audienceEvent.EventEarn), _audienceEvent.EventEarn);
    }
    public void EventChangeIncrease()
    {
        _audienceEvent.EventChance += 1;
        PlayerPrefs.SetInt(nameof(_audienceEvent.EventChance), _audienceEvent.EventChance);
    }
    public void EventNumberIncrease()
    {
        _audienceEvent.EventNumber += 1;
        PlayerPrefs.SetInt(nameof(_audienceEvent.EventNumber), _audienceEvent.EventNumber);
    }
}
