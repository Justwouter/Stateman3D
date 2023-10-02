using UnityEngine;

public class PlayerSprintState : APlayerState {

    public PlayerSprintState(PlayerStateManager psm) : base(psm) { }

    readonly float _movementSpeed = 15f;
    public override void EnterState() {
        Psm.StateIndicator.SetText("Sprint");
    }

    public override void ExitState() { }

    public override void UpdateState() {
        Psm.Player.transform.Translate(_movementSpeed * Time.deltaTime * Psm.Movement);
        if(SprintAction.triggered){
            Psm.SwitchState(Psm.MoveState);
        }
    }
}