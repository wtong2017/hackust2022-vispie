using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LocationController : MonoBehaviour
{
    public DisplayPath path;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var selector = root.Q<RadioButtonGroup>("selector");

        selector.RegisterValueChangedCallback(value => path.SetPath(value.newValue));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
