using UnityEngine;
using System.Collections;

public enum PlayerState
{
    PLAYER_SPAWNING,
    PLAYER_IDLE,
    PLAYER_MOVING,
    PLAYER_ATTACKING,
    PLAYER_HIT,
    PLAYER_DYING,
    PLAYER_DEAD
}

public class Player : MonoBehaviour {

    // The player's current state
    PlayerState CurrentState = PlayerState.PLAYER_IDLE;

    // Update is called once per frame
    void Update() {
        // Player STATE MACHINE
        switch (CurrentState)
        {
            case PlayerState.PLAYER_IDLE:
                break;

        }
    }
}
