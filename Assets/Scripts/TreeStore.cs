using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeStore : MonoBehaviour
{
    // TODO: using scriptable objects to store different tree information
    //static public int TreeCost = 10;
    //public GameObject treePrefab;
    public List<TreeType> treeTypes;

    private List<TreeController> treeObjList;

    // Start is called before the first frame update
    void Start()
    {
        treeObjList = new List<TreeController>();
    }

    public void PlantTree(PlayerController player, int treeTypeIndex, Vector3 location) {
        var selectedTree = treeTypes[treeTypeIndex];
        var treeObj = Instantiate(selectedTree.prefab, location, Quaternion.identity);
        var treeController = treeObj.GetComponent<TreeController>();
        treeController.Initialize(player, selectedTree.cost);
        treeObjList.Add(treeController);
    }

    public int GetPrice(int treeTypeIndex) {
        return treeTypes[treeTypeIndex].cost;
    }

    public void PlantTreeWithAnchor(PlayerController player, int treeTypeIndex, GameObject anchor) {
        var selectedTree = treeTypes[treeTypeIndex];
        var treeObj = Instantiate(selectedTree.prefab, Vector3.zero, Quaternion.identity);
        treeObj.transform.SetParent(anchor.transform, false);
        var treeController = treeObj.GetComponent<TreeController>();
        treeController.Initialize(player, selectedTree.cost);
        treeObjList.Add(treeController);
    }
}
