using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class AudienceEvent : MonoBehaviour
{
    public int EventRatio;
    public GameObject[] AudienceEventAreaCorner = new GameObject[4];
    public GameObject EventEffectUI;

    private AudioSource _audioSource;
    public List<AudioClip> GeneralAudioClips = new List<AudioClip>();
    private List<AudioClip> _currentAudioClips;

    private DataSave _dataSave;
    public StanUpShow StandUpShow;

    private void Start()
    {
        _dataSave = FindObjectOfType<DataSave>();
        StandUpShow = FindObjectOfType<StanUpShow>();
        _currentAudioClips = GeneralAudioClips;
        _audioSource = GetComponent<AudioSource>();
    }

    public void EventCreate()
    {
        Vector3 eventPos = new Vector3(Random.Range(AudienceEventAreaCorner[0].transform.position.x, AudienceEventAreaCorner[2].transform.position.x)
            ,Random.Range(AudienceEventAreaCorner[1].transform.position.y, AudienceEventAreaCorner[0].transform.position.y),0);

        Instantiate(EventEffectUI, eventPos,Quaternion.identity,FindObjectOfType<Canvas>().gameObject.transform);
    }
    public void EventEnter()
    {
        if(_currentAudioClips.Count <= 0)
        {
            _currentAudioClips = GeneralAudioClips;
        }

        StandUpShow.earnedMoney += (ulong)(_dataSave.CurrentStage.ShowTicketPrice + (int)(_dataSave.CurrentStage.StageEaringIncrease / 1000));


        int randomNum = Random.Range(0, _currentAudioClips.Count);
        _audioSource.clip = _currentAudioClips[randomNum];
        _currentAudioClips.Remove(_currentAudioClips[randomNum]);
        _audioSource.Play();
    }

    public IEnumerator RandomTimeCreateEvent()
    {
        float time;
        while(StandUpShow.isShowContinue)
        {
            time = Random.Range(_dataSave.ShowTime / 4, _dataSave.ShowTime / 2);
            yield return new WaitForSecondsRealtime(time);
            if(StandUpShow._currentShowTime > time)
                EventCreate();
        }
    }
}
