using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventProductManager : MonoBehaviour
{
    [SerializeField] EventProductType _eventProductType;

    public int ProductPrice;
    private AudienceEvent _audienceEvent;
    public AudienceEventShop audienceEventShop;
    private DataSave dataSave;

    private void Start()
    {
        _audienceEvent = FindObjectOfType<AudienceEvent>();
        audienceEventShop = FindObjectOfType<AudienceEventShop>();
        dataSave = FindObjectOfType<DataSave>();

        switch (_eventProductType)
        {
            case EventProductType.EventRatio:
                gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Event Ratio\n" + _audienceEvent.EventRatio.ToString();
                break;
            case EventProductType.EventNumber:
                if (PlayerPrefs.GetInt(nameof(_audienceEvent.EventNumber)) == 0)
                {
                    PlayerPrefs.SetInt(nameof(_audienceEvent.EventNumber), 1);
                    _audienceEvent.EventNumber = PlayerPrefs.GetInt(nameof(_audienceEvent.EventNumber));
                }
                gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Event Number\n" + _audienceEvent.EventNumber.ToString();
                break;
            case EventProductType.EventTime:
                gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Event Time\n" + _audienceEvent.EventTime.ToString();
                break;
            case EventProductType.EventEarn:
                gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Event Earn\n" + _audienceEvent.EventEarn.ToString();
                break;
            case EventProductType.EventChance:
                gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Event Chance\n" + _audienceEvent.EventChance.ToString();
                break;
        }
    }

    public void SetProductData()
    {
        switch(_eventProductType)
        {
            case EventProductType.EventRatio:
                if(dataSave.Money >= ProductPrice)
                {
                    dataSave.Money -= ProductPrice;
                    audienceEventShop.EventRatioIncrease();
                }
                gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Event Ratio\n" + _audienceEvent.EventRatio.ToString();
                break;
            case EventProductType.EventNumber:
                if (PlayerPrefs.GetInt(nameof(_audienceEvent.EventNumber)) == 0)
                {
                    PlayerPrefs.SetInt(nameof(_audienceEvent.EventNumber), 1);
                    _audienceEvent.EventNumber = PlayerPrefs.GetInt(nameof(_audienceEvent.EventNumber));
                }
                if (dataSave.Money >= ProductPrice)
                {
                    dataSave.Money -= ProductPrice;
                    audienceEventShop.EventNumberIncrease();
                }
                gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Event Number\n" + _audienceEvent.EventNumber.ToString();
                break;
            case EventProductType.EventTime:
                if (dataSave.Money >= ProductPrice)
                {
                    dataSave.Money -= ProductPrice;
                    audienceEventShop.EventTimeIncrease();
                }
                gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Event Time\n" + _audienceEvent.EventTime.ToString();
                break;
            case EventProductType.EventEarn:
                if (dataSave.Money >= ProductPrice)
                {
                    dataSave.Money -= ProductPrice;
                    audienceEventShop.EventEarnIncrease();
                }
                gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Event Earn\n" + _audienceEvent.EventEarn.ToString();
                break;
            case EventProductType.EventChance:
                if (dataSave.Money >= ProductPrice)
                {
                    dataSave.Money -= ProductPrice;
                    audienceEventShop.EventChangeIncrease();
                }
                gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Event Chance\n" + _audienceEvent.EventChance.ToString();
                break;
        }
    }
}
enum EventProductType
{
    EventRatio, EventTime,EventEarn,EventChance,EventNumber
}
