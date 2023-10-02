using UnityEngine;

public class PlayerIdleState : APlayerState {

    public PlayerIdleState(PlayerStateManager psm) : base(psm) { }
    readonly float _rotationSpeed = 100f;

    public override void EnterState() {
        Psm.StateIndicator.SetText("Idle");
    }

    public override void ExitState() { }

    public override void UpdateState() {
        Psm.Player.transform.Rotate(Psm.RotationDirection * _rotationSpeed * Time.deltaTime * Vector3.up);

        if (MoveAction.triggered) {
            Psm.SwitchState(Psm.MoveState);
        }
        else if (JumpAction.triggered) {
            Psm.SwitchState(Psm.JumpState);
        }

    }
}