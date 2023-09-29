using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpToStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        other.gameObject.transform.parent.gameObject.transform.position = new Vector3(-1.57f,9.3f,15.35f); // Main player object doesn't have a collider
    }
}
