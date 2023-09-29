using UnityEngine;

public class PlayerSprintState : APlayerState {

    readonly float _movementSpeed = 15f;
    public override void EnterState(PlayerStateManager psm) {
        psm.StateIndicator.SetText("Sprint");
    }

    public override void ExitState(PlayerStateManager psm) { }

    public override void UpdateState(PlayerStateManager psm) {
        psm.Player.transform.Translate(_movementSpeed* Time.deltaTime * psm.Movement);
    }
}