using UnityEngine;

public class PlayerMoveState : APlayerState {
    readonly float _movementSpeed = 10f;
    public override void EnterState(PlayerStateManager psm) {
        psm.StateIndicator.SetText("Move");
    }

    public override void ExitState(PlayerStateManager psm) { }

    public override void UpdateState(PlayerStateManager psm) {
        psm.Player.transform.Translate(_movementSpeed * Time.deltaTime * psm.Movement);
        if (psm.Movement == Vector3.zero) {
            psm.SwitchState(psm.IdleState);
        }
        else if (psm.Movement.y != 0) {
            psm.SwitchState(psm.JumpState);
        }
    }
}