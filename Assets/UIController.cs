using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    Label scoreLabel;
    Label titleLabel;
    Label bodyLabel;

    public ARController controller;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start() {
        var root = GetComponent<UIDocument>().rootVisualElement;
        scoreLabel = root.Q<Label>("score");

        titleLabel = root.Q<Label>("messageTitle");
        bodyLabel = root.Q<Label>("messageBody");

        var btn = root.Q<Button>("PlantBtn");
        btn.clicked += () => {
            var obj = controller.PerformHitTest();
            if (obj != null || playerController.isTest) {
                playerController.TryPlantTreeWithAnchor(obj);
            }
        };
    }

    public void SetUIMessage(string title, string body) {
        titleLabel.text = title;
        bodyLabel.text = body;
    }

    public void SetScore(int score) {
        scoreLabel.text = $"{score}";
    }
}
