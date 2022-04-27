using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class DisplayPath : MonoBehaviour
{
    public NavMeshAgent agent;
    public List<Transform> destinations = new List<Transform>();
    public int currDestIndex = 0;
    public float offsetHeight = 1f;
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        var destination = destinations[currDestIndex];
        agent.SetDestination(destination.position);
    }

    // Update is called once per frame
    void Update() {
        //var destination = destinations[currDestIndex];
        //if (destination.hasChanged) { 
        //    agent.SetDestination(destination.position);
        //    destination.hasChanged = false;
        //}
        if (agent.hasPath) {
            DrawPath();
        }
    }

    public void SetPath(int index) {
        currDestIndex = index;
        var destination = destinations[currDestIndex];
        agent.SetDestination(destination.position);
    }

    void DrawPath() {
        lineRenderer.positionCount = agent.path.corners.Length;

        if (agent.path.corners.Length < 2) {
            return;
        }

        lineRenderer.SetPositions(agent.path.corners.Select((pos) => new Vector3(pos.x, pos.y+offsetHeight, pos.z)).ToArray());
    }
}
