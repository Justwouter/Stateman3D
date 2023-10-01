using UnityEngine;

public class PlayerMoveState : APlayerState {

    public PlayerMoveState(PlayerStateManager psm) : base(psm){}

    readonly float _movementSpeed = 10f;
    public override void EnterState() {
        psm.StateIndicator.SetText("Move");
    }

    public override void ExitState() { }

    public override void UpdateState() {
        psm.Player.transform.Translate(_movementSpeed * Time.deltaTime * psm.Movement);
        if (psm.Movement == Vector3.zero) {
            psm.SwitchState(psm.IdleState);
        }
        else if(SprintAction.triggered){
            psm.SwitchState(psm.SprintState);
        }
        else if(JumpAction.triggered){
            psm.SwitchState(psm.JumpState);
        }
    }
}