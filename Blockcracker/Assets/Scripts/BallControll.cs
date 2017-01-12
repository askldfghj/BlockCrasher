using UnityEngine;
using System.Collections;

public class BallControll : MonoBehaviour {
    GameObject PlayerObj;
    Rigidbody2D rb2D;
    Sprite spr;
    public Vector3 dir;
    public int speed;
    int mAngle;
    enum CurrentMode { Ready, Shot };
    CurrentMode curmod;
    Vector3 pos;
    bool IsSecond;
    bool IsPower;
    void Awake()
    {
        PlayerObj = GameObject.Find("Plain");
        rb2D = GetComponent<Rigidbody2D>();
        IsSecond = false;
        IsPower = false;
        //curmod = CurrentMode.Ready;
        //pos = PlayerObj.transform.position;
        //pos.y += 0.26f;
        //transform.position = pos;
    }

    // Use this for initialization
    void Start () {

        
    }

    void Fire()
    {
        if (IsSecond)
        {
            int mod = 0;
            mod = Random.Range(0, 1);
            switch (mod)
            {
                case 0:
                    mAngle = Random.Range(10, 170);
                    break;
                case 1:
                    mAngle = Random.Range(190, 350);
                    break;
            }
            dir = new Vector3(Mathf.Cos(Mathf.PI * 2 * mAngle / 360), Mathf.Sin(Mathf.PI * 2 * mAngle / 360), 0f);
            dir *= speed;
            rb2D.velocity = dir;
            curmod = CurrentMode.Shot;
        }
        else
        {
            mAngle = Random.Range(45, 136);
            dir = new Vector3(Mathf.Cos(Mathf.PI * 2 * mAngle / 360), Mathf.Sin(Mathf.PI * 2 * mAngle / 360), 0f);
            dir *= speed;
            rb2D.velocity = dir;
            curmod = CurrentMode.Shot;
        }
    }

    void PowerUp()
    {
        IsPower = true;
        spr = (Sprite)Resources.Load("Sprites/ball_p", typeof(Sprite));
        gameObject.GetComponent<SpriteRenderer>().sprite = spr;
    }

    void PowerDown()
    {
        IsPower = false;
        spr = (Sprite)Resources.Load("Sprites/ball", typeof(Sprite));
        gameObject.GetComponent<SpriteRenderer>().sprite = spr;
    }

    // Update is called once per frame
    void Update ()
    {
        switch (curmod)
        {
            case CurrentMode.Ready:
                pos = PlayerObj.transform.position;
                pos.y += 0.26f;
                transform.position = pos;
                break;
            case CurrentMode.Shot:
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                break;
        }
	}

    void IsSecondBall()
    {
        IsSecond = true;
    }

    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsPower)
        {
            rb2D.velocity = Vector2.zero;

            //obtain the surface normal for a point on a collider 
            Vector2 CollisionNormal = collision.contacts[0].normal;

            //Reflects a vector off the plane defined by a normal.
            dir = Vector2.Reflect(dir, CollisionNormal);
            dir *= 1.01f;
            //apply new direction adding force
            rb2D.velocity = dir;
        }
        //reset force
        if (IsPower)
        {
            if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player")
            {
                rb2D.velocity = Vector2.zero;

                //obtain the surface normal for a point on a collider 
                Vector2 CollisionNormal = collision.contacts[0].normal;

                //Reflects a vector off the plane defined by a normal.
                dir = Vector3.Reflect(dir, CollisionNormal);
                dir *= 1.01f;
                //apply new direction adding force
                rb2D.velocity = dir;
            }
            else
            {
                rb2D.velocity = Vector2.zero;
                //apply new direction adding force
                rb2D.velocity = dir;
            }
        }
        
    }
}
