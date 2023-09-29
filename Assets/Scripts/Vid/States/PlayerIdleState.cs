using UnityEngine;

public class PlayerIdleState : APlayerState {
    readonly float _rotationSpeed = 100f;

    public override void EnterState(PlayerStateManager psm) {
        psm.StateIndicator.SetText("Idle");
        psm.Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public override void ExitState(PlayerStateManager psm) {}

    public override void UpdateState(PlayerStateManager psm) {
        psm.Player.transform.Rotate(psm.RotationDirection * _rotationSpeed * Time.deltaTime * Vector3.up); //Rotation always works

    }
}