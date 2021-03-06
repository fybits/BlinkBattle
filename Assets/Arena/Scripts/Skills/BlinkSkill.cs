﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkSkill : SkillBase
{
    Player player;
    float timer = 0.2f;
    bool isOnCoolDown = false;

    public BlinkSkill (Player player, float cooldown) {
        this.player = player;
        this.cooldown = cooldown;
    }


    public override void Cast() {
        if (!isOnCoolDown) {
            isOnCoolDown = true;
            player.StartCoroutine(Skill());
        }
    }

    IEnumerator Skill () {
        GameObject.Instantiate(player.particles, player.transform.position, Quaternion.identity);

        player.GetComponent<Collider2D>().enabled = false;
        Vector2 tempVel = player.vel;

        float angle = player.transform.eulerAngles.z;

        int coef = 1;
        if (angle < 0)
            coef = -1;

        Vector2 plMovDir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad) * coef, Mathf.Sin(angle * Mathf.Deg2Rad) * coef);

        player.vel = plMovDir.normalized*0.5f;

        while (timer > 0) {
            timer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        player.vel = tempVel;
        player.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(cooldown);
        timer = 0.2f;
        isOnCoolDown = false;
    }
}
