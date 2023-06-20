using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineController))]
public class LineController : MonoBehaviour
{
    [SerializeField] private List<Transform> nodes;
    
    private LineRenderer lineRenderer;

    private void Start() 
    {
        lineRenderer=GetComponent<LineRenderer>();
        lineRenderer.positionCount=nodes.Count;
        
    }

    private void Update() 
    {
        lineRenderer.SetPositions(nodes.ConvertAll(n=>n.position-new Vector3(0,0,5)).ToArray());
        
    }

    public Vector3[] GetPositions()
    {
        Vector3[] positions=new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(positions);
        return positions;
    }

    public float GetWidth()
    {
        return lineRenderer.startWidth;
    }
    
}
