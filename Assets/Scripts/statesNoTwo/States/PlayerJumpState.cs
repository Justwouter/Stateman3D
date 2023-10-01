using UnityEngine;

public class PlayerJumpState : APlayerState {

    public PlayerJumpState(PlayerStateManager psm) : base(psm) { }
    public float JumpHight = 10f;

    public override void EnterState() {
        psm.StateIndicator.SetText("Jump");
        psm.Player.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpHight, ForceMode.Impulse);
    }

    public override void ExitState() {
        psm.Movement.y = 0;
    }   

    public override void UpdateState() {
        psm.Player.transform.Translate(10 * Time.deltaTime * new Vector3(psm.Movement.x, 0, psm.Movement.z));
        if (HasHitGround(psm)) {
            if (psm.Movement == Vector3.zero) {
                psm.SwitchState(psm.IdleState);
            }
            else {
                psm.SwitchState(psm.MoveState);
            }
        }
        

    }

    public bool HasHitGround(PlayerStateManager psm) {
        Debug.DrawRay(psm.Player.transform.position, Vector3.down * 1f, Color.green);
        Ray ray = new(psm.Player.transform.position, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, 1f)) {
            if (hit.collider.gameObject.transform.parent.name.Contains("Map")) {
                Debug.DrawRay(psm.Player.transform.position, Vector3.down * 1f, Color.red);

                return true;
            }
        }

        return false;
    }
}