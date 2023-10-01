using UnityEngine;

public class PlayerSprintState : APlayerState {

    public PlayerSprintState(PlayerStateManager psm) : base(psm) { }

    readonly float _movementSpeed = 15f;
    public override void EnterState() {
        psm.StateIndicator.SetText("Sprint");
    }

    public override void ExitState() { }

    public override void UpdateState() {
        psm.Player.transform.Translate(_movementSpeed * Time.deltaTime * psm.Movement);
        if(SprintAction.triggered){
            psm.SwitchState(psm.MoveState);
        }
    }
}