using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ScoreController))]
public class PlayerController : MonoBehaviour
{
    public TreeStore treeStore; // this could be a singleton
    private ScoreController scoreController;
    public GameObject ARCamera;
    Collider[] hitColliders = new Collider[10];
    public float searchEventRadius = 15;

    [Header("UI")]
    public UIController uiController;

    [Header("Test")]
    [SerializeField] List<GameObject> testLocations = new List<GameObject>();
    public bool isTest = false;

    // Start is called before the first frame update
    void Start() {
        scoreController = GetComponent<ScoreController>();

        scoreController.Initialize(15);
    }

    //public void OnGUI() {
    //    GUI.Label(new Rect(100, 100, 300, 200), $"{scoreController.Score}");
    //}

    private void Update() {
        if (ARCamera.activeSelf) {
            LookForGreenEvent();
        }

        uiController.SetScore(scoreController.Score);

    }

    void LookForGreenEvent() {
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, searchEventRadius, hitColliders);
        for (int i = 0; i < numColliders; i++) {
            EventController eventController;
            if (hitColliders[i].gameObject.TryGetComponent(out eventController)) {
                eventController.ActivateTarget(true);
            }
        }
    }

    private void OnDrawGizmos() {
        if (ARCamera.activeSelf) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, searchEventRadius);
        }
    }

    public bool TryPlantTree(int treeTypeIndex, Vector3 position) {
        if (TryDeductPoints(treeStore.GetPrice(treeTypeIndex))) {
            treeStore.PlantTree(this, treeTypeIndex, position);
            return true;
        }
        return false;
    }

    public void TryPlantTreeWithAnchor(GameObject anchor) {
        if (isTest && testLocations.Count != 0) {
            TryPlantTree(0, testLocations[0]);
        } else {
            TryPlantTree(0, anchor);
        }
    }

    private bool TryPlantTree(int treeTypeIndex, GameObject anchor) {
        if (TryDeductPoints(treeStore.GetPrice(treeTypeIndex))) {
            treeStore.PlantTreeWithAnchor(this, treeTypeIndex, anchor);
            return true;
        }
        return false;
    }

    public bool TryDeductPoints(int points) {
        if (scoreController.Score >= points) {
            scoreController.DeductPoints(points);
            return true;
        }
        return false;
    }

    public void GainPoints(int points) {
        scoreController.AddPoints(points);
    }

    public void OnPlant(InputValue value) {
        if (value.isPressed) {
            // TODO: only plant one tree now
            if (TryPlantTree(0, transform.position)) {
                Debug.Log("onPlant success");
            }
            else {
                Debug.Log("onPlant failed");
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        EventController eventController;
        if (other.gameObject.TryGetComponent(out eventController)) {
            EventObject evtObj = eventController.GetEvent();
            eventController.ShowMark(false);
            uiController.SetUIMessage("Get Points with", evtObj.eventName);
            GainPoints(evtObj.pointsGain);
        }
    }

    private void OnTriggerExit(Collider other) {
        EventController eventController;
        if (other.gameObject.TryGetComponent(out eventController)) {
            eventController.ShowMark(true);
            uiController.SetUIMessage("Grow Trees with", "Green Events");
        }
    }
}
