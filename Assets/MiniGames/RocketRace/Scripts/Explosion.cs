using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Vector3 vel;

    private void Update() {
        transform.position += vel * Time.deltaTime;    
    }

    void OnAnimationEnded() {
        Destroy(gameObject);
    }
}
