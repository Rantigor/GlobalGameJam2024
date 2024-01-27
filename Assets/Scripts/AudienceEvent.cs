using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class AudienceEvent : MonoBehaviour
{
    public int EventRatio = 10;//Deneme sýklýðý
    public int EventTime;//event süresi
    public int EventEarn;//event kazancý
    public int EventChance;//çýkma þansý
    public int EventNumber = 1;//ayný anda kaç tane çýkabilir
    private int _entyrNumber = 0;

    public GameObject[] AudienceEventAreaCorner = new GameObject[4];
    public GameObject EventEffectUI;

    private AudioSource _audioSource;
    public List<AudioClip> GeneralAudioClips = new List<AudioClip>();
    private List<AudioClip> _currentAudioClips;

    public StanUpShow StandUpShow;

    private void Start()
    {
        StandUpShow = FindObjectOfType<StanUpShow>();
        _audioSource = GetComponent<AudioSource>();
        _currentAudioClips = new List<AudioClip>(GeneralAudioClips);
        _entyrNumber = PlayerPrefs.GetInt(nameof(_entyrNumber));

        if(_entyrNumber == 0)
        {
            SaveEventData();
            _entyrNumber++;
            PlayerPrefs.SetInt(nameof(_entyrNumber), _entyrNumber);
        }
    }

    public void EventCreate()
    {
        Vector3 eventPos = new Vector3(Random.Range(AudienceEventAreaCorner[0].transform.position.x, AudienceEventAreaCorner[2].transform.position.x)
            ,Random.Range(AudienceEventAreaCorner[1].transform.position.y, AudienceEventAreaCorner[0].transform.position.y),0);

        Instantiate(EventEffectUI, eventPos, Quaternion.identity, FindObjectOfType<Canvas>().gameObject.transform).GetComponent<Transform>().SetSiblingIndex(5);
    }
    public void EventEnter()
    {
        StandUpShow.earnedMoney += (ulong)EventEarn;

        int randomNum = Random.Range(0, _currentAudioClips.Count);
        _audioSource.PlayOneShot(_currentAudioClips[randomNum]);
        _currentAudioClips.Remove(_currentAudioClips[randomNum]);

        if(_currentAudioClips.Count <= 0)
        {
            _currentAudioClips = new List<AudioClip>(GeneralAudioClips);
        }
    }

    public IEnumerator RandomTimeCreateEvent()
    {
        while(StandUpShow.isShowContinue)
        {
            yield return new WaitForSecondsRealtime(1);
            int randomNum = Random.Range(0, 100);
            //EventChance arttýkça event çýkma olasýlýðý artar
            if(StandUpShow._currentShowTime > 0.5f && FindObjectsOfType<AudienceEventClicker>().Length <= EventNumber && randomNum <= EventChance)
                EventCreate();
            yield return new WaitForSecondsRealtime(EventRatio - 1);
        }
    }

    public void SaveEventData()
    {
        PlayerPrefs.SetInt(nameof(EventRatio), EventRatio);
        PlayerPrefs.SetInt(nameof(EventChance), EventChance);
        PlayerPrefs.SetInt(nameof(EventEarn), EventEarn);
        PlayerPrefs.SetInt(nameof(EventTime), EventTime);
        PlayerPrefs.SetInt(nameof(EventNumber), EventNumber);
    }
    public void LoadEventData()
    {
        EventRatio = PlayerPrefs.GetInt(nameof(EventRatio));
        EventChance = PlayerPrefs.GetInt(nameof(EventChance));
        EventEarn = PlayerPrefs.GetInt(nameof(EventEarn));
        EventTime = PlayerPrefs.GetInt(nameof(EventTime));
        EventNumber = PlayerPrefs.GetInt(nameof(EventNumber));
    }
}
