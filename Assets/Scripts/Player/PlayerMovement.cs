using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 firstPosition;
    private Vector3 lastPosition;

    private float dragDistance;
    private bool canClick;

    private int increaseAmount;


    private void Awake()
    {
        canClick = true;
        level = 0;
        currentRadius = _startRadius;
    }

    private void Start() 
    {
        dragDistance=Screen.height*15/100;
    }

    private void Update()
    {
        if(canClick && Input.GetMouseButtonDown(0))
        {
            //CheckMove();
            StartCoroutine(ChangeRadius());
            EventManager.Broadcast(GameEvent.OnFingerPress);
        }
    }

    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Transform _rotateTransform;

    private void FixedUpdate()
    {
        transform.localPosition = Vector3.up * currentRadius;
        float rotateValue = _rotateSpeed * Time.fixedDeltaTime * _startRadius / currentRadius;
        _rotateTransform.Rotate(0, 0, rotateValue);
    }

    


    [SerializeField] private float _startRadius;
    [SerializeField] private float _moveTime;

    [SerializeField] private List<float> _rotateRadius;
    private float currentRadius;

    private int level;


    private IEnumerator ChangeRadius()
    {
        canClick = false;
        float moveStartRadius = _rotateRadius[level];
        float moveEndRadius = _rotateRadius[(level + 1) % _rotateRadius.Count];
        float moveOffset = moveEndRadius - moveStartRadius;
        float speed = 1 / _moveTime;
        float timeElasped = 0f;
        while(timeElasped < 1f)
        {
            timeElasped += speed * Time.fixedDeltaTime;
            currentRadius = moveStartRadius + timeElasped * moveOffset;
            yield return new WaitForFixedUpdate();
        }

        canClick = true;
        level = (level + 1) % _rotateRadius.Count;
        currentRadius = _rotateRadius[level];
    }

    private void CheckMove()
    {

        if(Input.touchCount>0)
        {
            Touch touch=Input.GetTouch(0);
            if(touch.phase==TouchPhase.Began)
            {
                firstPosition=touch.position;
                lastPosition=touch.position;
            }

            else if(touch.phase==TouchPhase.Moved)
            {
                lastPosition=touch.position;
            }

            else if(touch.phase==TouchPhase.Ended)
            {
                lastPosition=touch.position;

                if(Mathf.Abs(lastPosition.x-firstPosition.x)>Mathf.Abs(lastPosition.y-firstPosition.y))
                {
                    if(lastPosition.x>firstPosition.x)
                    {
                        //right
                    }
                    else
                    {
                        //left
                    }
                }

                else
                {
                    if(lastPosition.y>firstPosition.y)
                    {
                        //up
                        increaseAmount=1;
                    }
                    else
                    {
                        increaseAmount=-1;
                        //down
                    }
                }
            }
        }
    }

}
