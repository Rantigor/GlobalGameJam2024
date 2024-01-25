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

   
    public void EventCreate()
    {
        Vector3 eventPos = new Vector3(Random.Range(AudienceEventAreaCorner[0].transform.position.x, AudienceEventAreaCorner[2].transform.position.x)
            ,Random.Range(AudienceEventAreaCorner[1].transform.position.y, AudienceEventAreaCorner[0].transform.position.y),0);

        Instantiate(EventEffectUI, eventPos,Quaternion.identity,FindObjectOfType<Canvas>().gameObject.transform);
    }
    public void EventEnter()
    {
        print("Event Hobb");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            EventCreate();
        }
    }
}
