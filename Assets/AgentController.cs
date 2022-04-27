using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        transform.position= cam.transform.position;
        transform.rotation = cam.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
