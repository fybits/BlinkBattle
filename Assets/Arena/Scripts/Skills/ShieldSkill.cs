using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSkill : SkillBase
{
    Player player;
    GameObject shield;
    bool isOnCoolDown = false;

    public ShieldSkill (Player player) {
        this.player = player;
        shield = GameObject.Instantiate(player.shield, player.transform);
    }

    public void Cast() {
        if (!isOnCoolDown) {
            isOnCoolDown = true;
            player.StartCoroutine(Skill());
        }
    }

    IEnumerator Skill() {
        shield.SetActive(true);
        player.defense = 0.5f;
        yield return new WaitForSeconds(2);
        player.defense = 1f;
        shield.SetActive(false);
        yield return new WaitForSeconds(5);
        isOnCoolDown = false;
    }
}
