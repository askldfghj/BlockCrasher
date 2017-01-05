using UnityEngine;
using System.Collections;

public class ItemControll_Power : MonoBehaviour {

    GameObject PlainObj;

    Rigidbody2D rb2d;
    Vector2 dir;
    // Use this for initialization

    void Awake()
    {
        PlainObj = GameObject.Find("Plain");
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * 270 / 360), Mathf.Sin(Mathf.PI * 2 * 270 / 360));
        dir *= 2;
        rb2d.velocity = dir;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -0.5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D Coll)
    {
        if (Coll.gameObject.tag == "Player")
        {
            PlainObj.SendMessage("PowerUp");
            Destroy(gameObject);
        }
    }
}
