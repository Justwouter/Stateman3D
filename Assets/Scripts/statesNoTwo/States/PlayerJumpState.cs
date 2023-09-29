using UnityEngine;

public class PlayerJumpState : APlayerState {
    public float JumpHight = 100f;

    public override void EnterState(PlayerStateManager psm) {
        psm.StateIndicator.SetText("Jump");
        psm.Player.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpHight, ForceMode.Impulse);
    }

    public override void ExitState(PlayerStateManager psm) {
        psm.Movement.y = 0;
    }

    public override void UpdateState(PlayerStateManager psm) {
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
        // Ray ray = new(psm.Player.transform.position, new Vector3(0,-10,0));
        // Debug.DrawRay(psm.Player.transform.position, new Vector3(0,-10,0), Color.blue);

        // if(Physics.Raycast(ray, out _, -Mathf.Infinity)){
        //     Debug.Log("Hit!");
        //     return true;
        // }
        // Debug.Log("noHit");
        // return false;
        return psm.Player.GetComponent<Rigidbody>().velocity.y == 0;
    }
}