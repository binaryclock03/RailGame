using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endNodeController : MonoBehaviour
{
    public GameObject nodeEndPrefab;
    public GameObject trackSegment;
    GameObject[] nodes;

    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = trackSegment.GetComponent<LineRenderer>();

        nodes = new GameObject[2];

        nodes[0] = Instantiate(nodeEndPrefab, lineRenderer.GetPosition(0) , Quaternion.identity, trackSegment.transform);
        nodes[1] = Instantiate(nodeEndPrefab, lineRenderer.GetPosition(lineRenderer.positionCount - 1), Quaternion.identity, trackSegment.transform);
    }

    // Update is called once per frame
    void Update()
    {
        //update node positions as line changes
        nodes[0].transform.position = lineRenderer.GetPosition(0);
        nodes[1].transform.position = lineRenderer.GetPosition(lineRenderer.positionCount - 1);
    }
}
