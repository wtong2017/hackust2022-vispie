using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public EventObject eventObject;
    public GameObject mark;
    public Target target;

    private Guid Latest;

    public EventObject GetEvent() {
        return eventObject;
    }

    public void ShowMark(bool show) {
        mark.SetActive(show);
    }

    public void ActivateTarget(bool activate) {
        target.enabled = activate;

        if (activate) {
            StartCoroutine(Debounced());
        }
    }

    private IEnumerator Debounced() {
        // generate a new id and set it as the latest one 
        var guid = Guid.NewGuid();
        Latest = guid;

        // set the denounce duration here
        yield return new WaitForSeconds(1);

        // check if this call is still the latest one
        if (Latest == guid) {
            // place your debounced input handler code here
            ActivateTarget(false);
        }
    }
}
