using UnityEngine;

[CreateAssetMenu(fileName = "TreeType", menuName = "ScriptableObjects/TreeType", order = 1)]
public class TreeType : ScriptableObject
{
    public string treeType;
    public int cost;
    public GameObject prefab;
}