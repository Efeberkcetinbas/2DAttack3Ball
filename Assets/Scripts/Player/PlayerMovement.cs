using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;


    public Rigidbody2D rb;

    private Vector3 dragStartPos;
    private Touch touch;

    public LineRendererManager lrManager;

    public bool canShoot=false;

    private Camera cm;

    

    private void Start()
    {
        cm=Camera.main;
    }
    
    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnNextLevel,StopSpinning);
        
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnNextLevel,StopSpinning);
    }

    private void StopSpinning()
    {
        rb.constraints=RigidbodyConstraints2D.FreezeRotation;
    }



    private void Update()
    {
        
        if(canShoot)
            DragControl();
            
    }

    

    private void DragControl()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }
            if (touch.phase == TouchPhase.Ended)
            {
                DragRealease();
            }
        }
    }
    private void DragStart()
    {
        dragStartPos = cm.ScreenToWorldPoint(touch.position);
        rb.constraints=RigidbodyConstraints2D.None;
        dragStartPos.z = 0f;
        lrManager.lineRenderer.positionCount = 1;
        lrManager.lineRenderer.SetPosition(0, dragStartPos);
        //gameManager.canCollide=false;
        //gameManager.LineOpenControl(ballManager.index);
    }
    private void Dragging()
    {
        Vector3 draggingPos = cm.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
        lrManager.lineRenderer.positionCount = 2;
        lrManager.lineRenderer.SetPosition(1, draggingPos);
    }
    private void DragRealease()
    {
        lrManager.lineRenderer.positionCount = 0;

        Vector3 dragReleasePos = cm.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
        //GameManager.Instance.isWall=false;

        Vector3 force = dragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;
        rb.AddForce(clampedForce, ForceMode2D.Impulse);
        //gameManager.canCollide=true;
        //EventManager.Broadcast(GameEvent.OnFingerRelease);

        

        
        
        //StartCoroutine(Call());
    }

    /*private IEnumerator Call()
    {
        yield return null;
        CallBallManager();
    }*/

    /*private void CallBallManager()
    {
        ballManager.IncreaseIndex();
        ballManager.CheckIndex();
        ballManager.OpenSignal();

        /*
        Added For Trying Progress and Requirement
        */
        
    //}

}
