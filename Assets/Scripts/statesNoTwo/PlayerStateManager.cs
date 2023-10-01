using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour {

    public GameObject Player;
    public PlayerInput PlayerInput;
    public TextMeshProUGUI StateIndicator;
    public APlayerState _currentState; //public for test remove in prod
    public PlayerIdleState IdleState;
    public PlayerMoveState MoveState;
    public PlayerJumpState JumpState;
    public PlayerSprintState SprintState;

    public float RotationDirection = 0f;
    public float MovementSpeed = 0f;
    public Vector3 Movement = Vector3.zero;



    void Start() {
        IdleState = new(this);
        MoveState = new(this);
        JumpState = new(this);
        SprintState = new(this);


        _currentState = IdleState;
        _currentState.EnterState();
    }

    // Update is called once per frame
    void Update() {
        _currentState.UpdateState();

    }

    public void SwitchState(APlayerState state) {
        _currentState.ExitState();
        _currentState = state;
        state.EnterState();
    }


    void OnRotate(InputValue inputValue) {
        RotationDirection = inputValue.Get<Vector2>().x;
    }
    void OnMove(InputValue inputValue) {
        Movement = inputValue.Get<Vector3>();
    }

    void OnSprint(InputValue inputValue) {}

    void OnJump(InputValue inputValue) {
        Movement = new Vector3(Movement.x, 1,Movement.z);
    }

}
