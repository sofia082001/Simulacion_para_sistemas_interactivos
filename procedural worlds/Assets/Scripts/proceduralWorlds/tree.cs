using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    [SerializeField] private GameObject branchPrefab;
    [SerializeField] private int maxDepth = 4;

    private Queue<GameObject> rootBranches = new Queue<GameObject>();
    private int currentDepth = 0;
    void Start()
    {
        GameObject root = Instantiate(branchPrefab, transform);
        root.name = "Branch [Root]";
        rootBranches.Enqueue(root);
        GenerateTree();
    }

    // Update is called once per frame
    void Update()
    {
        
    }private void GenerateTree()
    {
        if (currentDepth >= maxDepth)
        {
            return;
        }
        currentDepth++;

        Queue<GameObject> newBranches = new Queue<GameObject>();
        //GameObject[] createdThisLevel = new GameObject[(int)Mathf.Pow(2, currentDepth)];
        while(rootBranches.Count > 0)
        {
            var prevRoot = rootBranches.Dequeue();
            
            var leftBranch = CreateBranch(prevRoot, Random.Range(5f, 40));
            var RightBranch = CreateBranch(prevRoot, -Random.Range(5f,40));

            //create the pair of branches
            newBranches.Enqueue(leftBranch);
            newBranches.Enqueue(RightBranch);
        }
        rootBranches = newBranches;  
        GenerateTree();
    }

    private GameObject CreateBranch(GameObject prevBranch, float offsetAngle)
    {
        
        GameObject branch = Instantiate(branchPrefab, transform);
        branch.transform.position = prevBranch.transform.position + prevBranch.transform.up;     
        branch.transform.rotation = prevBranch.transform.rotation * Quaternion.Euler(0f,0f, offsetAngle);
        return branch;

    }
}
