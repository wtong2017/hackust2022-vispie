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
    private GameObject ARCamera;

    [Header("UI")]
    public TextMeshProUGUI scoreDisplay;


    // Start is called before the first frame update
    void Start() {
        scoreController = GetComponent<ScoreController>();

        scoreController.Initialize(15);

        ARCamera = GameObject.Find("ARCamera");
    }

    //public void OnGUI() {
    //    GUI.Label(new Rect(100, 100, 300, 200), $"{scoreController.Score}");
    //}

    private void Update() {
        if (ARCamera != null) {
            transform.position = ARCamera.transform.position;
        }

        scoreDisplay.text = $"Green Score: {scoreController.Score}";
    }

    public bool TryPlantTree(int treeTypeIndex, Vector3 position) {
        if (TryDeductPoints(treeStore.GetPrice(treeTypeIndex))) {
            treeStore.PlantTree(this, treeTypeIndex, position);
            return true;
        }
        return false;
    }

    public void TryPlantTreeWithAnchor(GameObject anchor) {
        TryPlantTree(0, anchor);
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
}
