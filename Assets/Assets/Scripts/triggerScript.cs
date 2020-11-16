using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class triggerScript : MonoBehaviour
{
    GameObject squirrelFW;
    private bool completed = false;

    public void checkSkipPossible()
    {
        squirrelFW.SetActive(completed);
        squirrelFW.transform.Rotate(0, 0, 50 * Time.deltaTime);
    }

    public void setCompleted()
    {
        this.completed = true;
    }

    void Start()
    {
        squirrelFW = GameObject.Find("squirrel.fw");
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
        squirrelFW.transform.Rotate(0,100 * Time.deltaTime, 0);
    }

    public void OnPointerDownDelegate(PointerEventData data)
    {
        Debug.Log("OnPointerDownDelegate called.");
        squirrelFW.transform.Rotate(50 * Time.deltaTime, 0, 0);
        setCompleted();
        checkSkipPossible();
    }

    // Update is called once per frame
    void Update()
    {
        //squirrelFW.transform.Rotate(0, 100 * Time.deltaTime, 0);
    }
}
