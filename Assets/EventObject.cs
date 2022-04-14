using UnityEngine;

[CreateAssetMenu(fileName = "GreenEvent", menuName = "ScriptableObjects/GreenEvent", order = 1)]
public class EventObject : ScriptableObject
{
    public string eventName;
    public int pointsGain;
}