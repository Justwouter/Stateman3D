using UnityEngine;

public class PlayerIdleState : APlayerState {

    public PlayerIdleState(PlayerStateManager psm) : base(psm) { }
    readonly float _rotationSpeed = 100f;

    public override void EnterState() {
        psm.StateIndicator.SetText("Idle");
    }

    public override void ExitState() { }

    public override void UpdateState() {
        psm.Player.transform.Rotate(psm.RotationDirection * _rotationSpeed * Time.deltaTime * Vector3.up);

        if (MoveAction.triggered) {
            psm.SwitchState(psm.MoveState);
        }
        else if (JumpAction.triggered) {
            psm.SwitchState(psm.JumpState);
        }

    }
}