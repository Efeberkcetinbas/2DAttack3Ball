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


    public GameData gameData;

    [SerializeField] private ParticleSystem trailEffect;



    private void Awake()
    {
        //canClick = true;
        canClick=false;
        level = 0;
        currentRadius = _startRadius;
    }

    private void Start() 
    {
        dragDistance=Screen.height*15/100;
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnStartGame,OnStartGame);
        
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnStartGame,OnStartGame);
    }

    private void Update()
    {
        if(!gameData.isGameEnd && canClick && Input.GetMouseButtonDown(0))
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
        if(!gameData.isGameEnd)
        {
            transform.localPosition = Vector3.up * currentRadius;
            float rotateValue = _rotateSpeed * Time.fixedDeltaTime * _startRadius / currentRadius;
            _rotateTransform.Rotate(0, 0, rotateValue);
        }
        else
        {
            //trailEffect.Stop();
        }
        
    }

    private void OnStartGame()
    {
        StartCoroutine(setTrueTouch());
    }

    private IEnumerator setTrueTouch()
    {
        yield return new WaitForSeconds(0.2f);
        //trailEffect.Play();
        canClick=true;
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
}
