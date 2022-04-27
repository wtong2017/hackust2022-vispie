using UnityEngine;

[CreateAssetMenu(fileName = "Anchor", menuName = "ScriptableObjects/Anchor", order = 1)]
public class Anchor : ScriptableObject
{
    public string anchorName;
    public string anchorID;
    public string nameInGame;
}