using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Transform _rotateTransform;

    public GameData gameData;

    private void FixedUpdate()
    {
        if(!gameData.isGameEnd)
            _rotateTransform.Rotate(0, 0, _rotateSpeed * Time.fixedDeltaTime);
    }
}
