
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class APlayerState {
    public PlayerStateManager psm;
    public InputAction MoveAction;
    public InputAction RotateAction;
    public InputAction JumpAction;
    public InputAction SprintAction;




    public APlayerState(PlayerStateManager psm){
        this.psm = psm;

        MoveAction = psm.PlayerInput.actions["Move"];
        RotateAction = psm.PlayerInput.actions["Rotate"];
        JumpAction = psm.PlayerInput.actions["Jump"];
        SprintAction = psm.PlayerInput.actions["Sprint"];


    }
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();

    public void HandleInput(){}
}
