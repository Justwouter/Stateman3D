using UnityEngine;

public class PlayerMoveState : APlayerState {

    public PlayerMoveState(PlayerStateManager psm) : base(psm){}

    readonly float _movementSpeed = 10f;
    public override void EnterState() {
        Psm.StateIndicator.SetText("Move");
    }

    public override void ExitState() { }

    public override void UpdateState() {
        Psm.Player.transform.Translate(_movementSpeed * Time.deltaTime * Psm.Movement);
        if (Psm.Movement == Vector3.zero) {
            Psm.SwitchState(Psm.IdleState);
        }
        else if(SprintAction.triggered){
            Psm.SwitchState(Psm.SprintState);
        }
        else if(JumpAction.triggered){
            Psm.SwitchState(Psm.JumpState);
        }
    }
}