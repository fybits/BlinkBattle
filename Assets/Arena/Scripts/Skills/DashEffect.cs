﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEffect : MonoBehaviour {
    void OnAnimationEnded() {
        Destroy(gameObject);
    }
}
