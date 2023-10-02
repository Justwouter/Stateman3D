using UnityEngine;

public class PlayerJumpState : APlayerState {

    public PlayerJumpState(PlayerStateManager psm) : base(psm) { }
    public float JumpHight = 10f;

    public override void EnterState() {
        Psm.StateIndicator.SetText("Jump");
        Psm.Player.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpHight, ForceMode.Impulse);
    }

    public override void ExitState() {
        Psm.Movement.y = 0;
    }   

    public override void UpdateState() {
        Psm.Player.transform.Translate(10 * Time.deltaTime * new Vector3(Psm.Movement.x, 0, Psm.Movement.z));
        if (HasHitGround(Psm)) {
            if (Psm.Movement == Vector3.zero) {
                Psm.SwitchState(Psm.IdleState);
            }
            else {
                Psm.SwitchState(Psm.MoveState);
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