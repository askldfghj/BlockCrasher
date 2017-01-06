using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlainCotroller : MonoBehaviour {
    
    public int speed;
    public GameObject BallObj;
    List<GameObject> BallobjList;
    const int powerMax = 300;
    int powerCount;
    enum LengthState { Short, Normal, Long }
    LengthState curLength;
    GameObject ball;
    bool IsDrag;
    bool IsPower;
    // Use this for initialization

    void Triple()
    {
        int index = Random.Range(0, BallobjList.Count);
        GameObject Ball1 = Instantiate(BallObj,
                                       BallobjList[index].transform.position,
                                       BallobjList[index].transform.rotation) as GameObject;
        GameObject Ball2 = Instantiate(BallObj,
                                       BallobjList[index].transform.position,
                                       BallobjList[index].transform.rotation) as GameObject;
        Ball1.SendMessage("IsSecondBall");
        Ball1.SendMessage("Fire");
        Ball2.SendMessage("IsSecondBall");
        Ball2.SendMessage("Fire");

        BallobjList.Add(Ball1);
        BallobjList.Add(Ball2);
    }

    void PowerUp()
    {
        powerCount = powerMax;
        for (int i = 0; i < BallobjList.Count; i++)
        {
            BallobjList[i].SendMessage("PowerUp");
        }
        IsPower = true;
    }

    void PowerDown()
    {
        for (int i = 0; i < BallobjList.Count; i++)
        {
            BallobjList[i].SendMessage("PowerDown");
        }
        IsPower = false;
    }

    void SpeedUp()
    {
        speed += 2;
    }

    void toShort()
    {
        switch (curLength)
        {
            case LengthState.Long:
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                curLength = LengthState.Normal;
                break;
            case LengthState.Normal:
                gameObject.transform.localScale = new Vector3(0.5f, 1, 1);
                curLength = LengthState.Short;
                break;
            case LengthState.Short:
                break;
        }
    }

    void toLong()
    {
        switch (curLength)
        {
            case LengthState.Long:
                break;
            case LengthState.Normal:
                gameObject.transform.localScale = new Vector3(1.5f, 1, 1);
                curLength = LengthState.Long;
                break;
            case LengthState.Short:
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                curLength = LengthState.Normal;
                break;
        }
    }

    void Awake()
    {
        BallobjList = new List<GameObject>();
        IsDrag = true;
        IsPower = false;
        curLength = LengthState.Normal;
        powerCount = 0;
    }
    
	void Start ()
    {
        ball = Instantiate(BallObj, new Vector3(transform.position.x,
                                                           transform.position.y + 0.26f,
                                                           transform.position.z),
                                                           new Quaternion()
                                                           ) as GameObject;
        BallobjList.Add(ball);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Z) && IsDrag)
        {
            ball.SendMessage("Fire");
            IsDrag = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed *Time.deltaTime);
        }
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6, 6), transform.position.y, 0.0f);

        CheckBall();
        if (CheckGameOver())
        {
            Destroy(gameObject);
        }
        if (IsPower)
        {
            powerCount--;
            if (powerCount == 0)
            {
                PowerDown();
            }
        }

    }

    void CheckBall()
    {
        for (int i = BallobjList.Count-1; i >= 0; i--)
        {
            if (BallobjList[i].transform.position.y < -0.5f || 
                BallobjList[i].transform.position.x < -7 ||
                BallobjList[i].transform.position.x > 7)
            {
                Destroy(BallobjList[i]);
                BallobjList.RemoveAt(i);
            }
        }
    }

    bool CheckGameOver()
    {
        if (BallobjList.Count == 0)
        {
            return true;
        }
        return false;
    }
}
