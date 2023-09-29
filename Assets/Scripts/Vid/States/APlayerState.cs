
using UnityEngine;

public abstract class APlayerState {
    public abstract void EnterState(PlayerStateManager psm);
    public abstract void UpdateState(PlayerStateManager psm);
    public abstract void ExitState(PlayerStateManager psm);


}
