using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(LineController),typeof(PolygonCollider2D))]
public class LineCollision : MonoBehaviour
{
    private LineController lineController;

    private PolygonCollider2D polygonCollider2D;

    private List<Vector2> colliderPoints=new List<Vector2>();
    
    private void Start() 
    {
        lineController=GetComponent<LineController>();
        polygonCollider2D=GetComponent<PolygonCollider2D>();    
    }

    private void Update() {
        colliderPoints=CalculateColliderPoints();
        polygonCollider2D.SetPath(0,colliderPoints.ConvertAll(p=>(Vector2)transform.InverseTransformPoint(p)));
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color=Color.red;
        if(colliderPoints!=null) colliderPoints.ForEach(p=>Gizmos.DrawSphere(p,0.1f));
    }

     private List<Vector2> CalculateColliderPoints() {
        //Get All positions on the line renderer
        Vector3[] positions = lineController.GetPositions();

        //Get the Width of the Line
        float width = lineController.GetWidth();

        //m = (y2 - y1) / (x2 - x1)
        float m = (positions[1].y - positions[0].y) / (positions[1].x - positions[0].x);
        float deltaX = (width / 2f) * (m / Mathf.Pow(m * m + 1, 0.5f));
        float deltaY = (width / 2f) * (1 / Mathf.Pow(1 + m * m, 0.5f));

        //Calculate the Offset from each point to the collision vertex
        Vector3[] offsets = new Vector3[2];
        offsets[0] = new Vector3(-deltaX, deltaY);
        offsets[1] = new Vector3(deltaX, -deltaY);

        //Generate the Colliders Vertices
        List<Vector2> colliderPositions = new List<Vector2> {
            positions[0] + offsets[0],
            positions[1] + offsets[0],
            positions[1] + offsets[1],
            positions[0] + offsets[1]
        };

        return colliderPositions;
    }


}
