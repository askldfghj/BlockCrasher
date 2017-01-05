using UnityEngine;
using System.Collections;

public class BlockControll : MonoBehaviour {
    bool IsCrash;
    public GameObject ItemObj;
    // Use this for initialization
    void Awake()
    {
        IsCrash = false;
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            IsCrash = true;
        }
    }

    void FixedUpdate()
    {
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
            Destroy(gameObject);
        }
    }

    public void SetItem(GameObject item)
    {
        ItemObj = item;
    }
}
