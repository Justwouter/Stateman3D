using UnityEngine;

public class PlayerIdleState : APlayerState {
    readonly float _rotationSpeed = 100f;

    public override void EnterState(PlayerStateManager psm) {
        psm.StateIndicator.SetText("Idle");
    }

    public override void ExitState(PlayerStateManager psm) { }

    public override void UpdateState(PlayerStateManager psm) {
        psm.Player.transform.Rotate(psm.RotationDirection * _rotationSpeed * Time.deltaTime * Vector3.up);
        if (psm.Movement != Vector3.zero) {
            psm.SwitchState(psm.MoveState);
        }


    }
}