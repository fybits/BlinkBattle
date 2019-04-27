using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    public int playerNum;
    public float maxSpeed = 1;

    public GameObject ghost;
    public GameObject explosion;

    public bool isDead = false;

    Vector2 vel;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Vector2 input = new Vector2(Input.GetAxisRaw("HorizontalP" + playerNum) * 180f,
                                    Input.GetAxisRaw("ActionP" + playerNum) * 40);
        if (Mathf.Abs(input.x) < 0.005)
            input.x = 0;

        vel = Vector3.ClampMagnitude(vel, maxSpeed* 6);

        vel += (input + Vector2.down * 21f) * Time.deltaTime;

        // 0.05f - 0.25f - 0.45f
        float XposOnScreen = Camera.main.WorldToViewportPoint(transform.position).x;
        float velocityKoeff = -40 * (XposOnScreen - 0.25f) * (XposOnScreen - 0.25f) + 1.6f;
        if (velocityKoeff > 1)
            velocityKoeff = 1;

        if (XposOnScreen < 0.25f && vel.x < 0 ||
            XposOnScreen > 0.25f && vel.x > 0)
            vel.x *= velocityKoeff;


        vel.x *= 0.5f;
        
        Vector3 newPos = transform.position + new Vector3(vel.x, vel.y, 0)*Time.deltaTime;


        if (newPos.y > Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y) // Teleportation
            newPos.y = Camera.main.ViewportToWorldPoint(Vector3.zero).y;

        if (newPos.y < Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y)
            newPos.y = Camera.main.ViewportToWorldPoint(Vector3.one).y;

        if (newPos.y > Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).y) // Ghost teleportation
            ghost.transform.position = new Vector3(transform.position.x, transform.position.y - Camera.main.orthographicSize * 2.0f, 0);

        if (newPos.y < Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).y)
            ghost.transform.position = new Vector3(transform.position.x, transform.position.y + Camera.main.orthographicSize * 2.0f, 0);

        transform.position = newPos;
    }

    public void Init(int playerNumber) {
        playerNum = playerNumber;
        Sprite playerSkin = Resources.Load<Sprite>("MiniGames/RocketRace/Sprites/Rocket_" + playerNum);
        if (playerSkin) {
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSkin;
            ghost.GetComponent<SpriteRenderer>().sprite = playerSkin;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        Obstacle obs = collision.GetComponent<Obstacle>();
        if (obs) {
            isDead = true;
            Explosion exp = Instantiate(explosion, transform.position, Quaternion.identity).GetComponent<Explosion>();
            exp.vel = -Vector3.right * collision.GetComponent<Obstacle>().speed;
            //SceneManager.LoadScene("rocketrace");
            gameObject.SetActive(false);
        }
    }
}
