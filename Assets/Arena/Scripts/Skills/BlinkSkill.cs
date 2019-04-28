using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkSkill : SkillBase
{
    Player player;
    float timer = 2;
    bool isOnCoolDown = false;

    public BlinkSkill (Player player) {
        this.player = player;
    }

    public void Cast() {
        if (!isOnCoolDown) {
            isOnCoolDown = true;
            player.StartCoroutine(Skill());
        }
    }

    IEnumerator Skill () {
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
        yield return new WaitForSeconds(5);
        timer = 2;
        isOnCoolDown = false;
    }
}
