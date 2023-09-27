using System.Collections;
using System.Collections.Generic;

using Unity.Mathematics;

using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    Vector3 _movement = Vector3.zero;
    [SerializeField] float _speed = 10;
    private float _rotationDirection = 0;
    [SerializeField] float _rotationSpeed = 10;


    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(_speed * Time.deltaTime * _movement);
        transform.Rotate(_rotationDirection*Vector3.up);
    }

    void OnMove(InputValue inputValue) {
        _movement = inputValue.Get<Vector3>();
    }

    void OnRotate(InputValue inputValue){
        _rotationDirection = inputValue.Get<Vector2>().x;
        Debug.Log(_rotationDirection);

    }
}
