using UnityEngine;
using System.Collections;

public class BlockControll_p : MonoBehaviour {

    GameObject ItemObj;
    bool IsCrash;
    public GameObject[] Items;
    public Sprite[] Sprites;
    void Awake()
    {
        IsCrash = false;
    }
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update () {
        if (IsCrash)
        {
            if (ItemObj != null)
            {
                GameObject item = Instantiate(ItemObj,
                                           new Vector3(gameObject.transform.position.x,
                                                       gameObject.transform.position.y,
                                                       gameObject.transform.position.z - 1),
                                           gameObject.transform.rotation) as GameObject;
                
            }
            IsCrash = false;
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            IsCrash = true;
        }
    }

    void SetItem()
    {
        ItemObj = Items[Random.Range(0, 5)];
    }

    void SetSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[1];
    }
}
