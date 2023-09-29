using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {
    Vector3 _movement = Vector3.zero;
    [SerializeField] public float Speed = 10f;
    [SerializeField] public float RotationSpeed = 100f;
    [SerializeField] public float JumpHight = 10f;
    private float _rotationDirection = 0f;
    private Rigidbody _rb;



    void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Speed * Time.deltaTime * _movement);
        transform.Rotate(_rotationDirection * RotationSpeed * Time.deltaTime * Vector3.up);
    }


    // Movement stuff

    void OnMove(InputValue inputValue) {
        _movement = inputValue.Get<Vector3>();
    }

    void OnRotate(InputValue inputValue) {
        _rotationDirection = inputValue.Get<Vector2>().x;
    }


    // // State 1, Sprinting
    // private bool _isSprinting = false;
    // public void OnSprint(InputValue inputValue) {
    //     _isSprinting = !_isSprinting;
    //     if (_isSprinting) {
    //         _speed += 5;
    //     }
    //     else {
    //         _speed -= 5;
    //     }
    // }
}
