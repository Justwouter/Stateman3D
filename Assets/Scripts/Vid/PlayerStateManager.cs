using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour {

    public GameObject Player;
    public TextMeshProUGUI StateIndicator;
    public APlayerState _currentState; //public for test remove in prod
    public PlayerIdleState IdleState = new();
    public PlayerMoveState MoveState = new();
    public PlayerJumpState JumpState = new();
    public PlayerSprintState SprintState = new();

    public Vector3 Movement = Vector3.zero;
    public float JumpHight = 10f;
    public float RotationDirection = 0f;



    void Start() {
        _currentState = IdleState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update() {
        _currentState.UpdateState(this);

    }

    public void SwitchState(APlayerState state){
        _currentState = state;
        state.EnterState(this);
    }



    //inputsystem fuckery
    void OnRotate(InputValue inputValue) {
        RotationDirection = inputValue.Get<Vector2>().x;
    }
    void OnMove(InputValue inputValue) {
        Movement = inputValue.Get<Vector3>();
        SwitchState(MoveState);
    }

    void OnSprint(InputValue inputValue) {
        if(_currentState == MoveState){
            SwitchState(SprintState);
        }
    }


}
