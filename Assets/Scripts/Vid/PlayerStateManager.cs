using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerStateManager : MonoBehaviour {
    APlayerState _currentState;
    public PlayerIdleState _idleState = new();
    public PlayerMoveState _moveState = new();
    public PlayerJumpState _jumpState = new();
    public PlayerSprintState _sprintState = new();

    void Start() {
        _currentState = _idleState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update() {
        _currentState.UpdateState(this);
    }

    void SwitchState(APlayerState state){
        _currentState = state;
        state.EnterState(this);
    }
}
