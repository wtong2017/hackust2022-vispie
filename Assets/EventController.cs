using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public EventObject eventObject;

    [Header("UI")]
    public TextMeshPro nameDisplay;

    private void Start() {
        nameDisplay.text = eventObject.eventName;
    }

    private void OnTriggerEnter(Collider other) {
        PlayerController player;
        if (other.gameObject.TryGetComponent(out player)) {
            player.GainPoints(eventObject.pointsGain);
        }
    }
}
