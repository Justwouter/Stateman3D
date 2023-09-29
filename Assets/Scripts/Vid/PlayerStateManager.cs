using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour {

    public GameObject Player;
    public TextMeshProUGUI StateIndicator;
    public APlayerState PreviousState;
    public APlayerState _currentState; //public for test remove in prod
    public PlayerIdleState IdleState = new();
    public PlayerMoveState MoveState = new();
    public PlayerJumpState JumpState = new();
    public PlayerSprintState SprintState = new();

    public Vector3 Movement = Vector3.zero;
    public float RotationDirection = 0f;
    public float MovementSpeed = 0f;



    void Start() {
        _currentState = IdleState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update() {
        _currentState.UpdateState(this);

    }

    public void SwitchState(APlayerState state) {
        _currentState.ExitState(this);
        _currentState = state;
        state.EnterState(this);
    }



    //inputsystem fuckery
    void OnRotate(InputValue inputValue) {
        RotationDirection = inputValue.Get<Vector2>().x;
    }
    void OnMove(InputValue inputValue) {
        Movement = inputValue.Get<Vector3>();
    }

    void OnSprint(InputValue inputValue) {
        if (_currentState == MoveState) {
            SwitchState(SprintState);
        }
        else if(_currentState == SprintState){
            SwitchState(MoveState);
        }
    }

    void OnJump(InputValue inputValue) {
        Movement = Vector3.up;
    }


}
