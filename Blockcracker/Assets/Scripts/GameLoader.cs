using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLoader : MonoBehaviour {

    public GameObject mBlock;
    List<GameObject> mBlockList;

    void Awake()
    {
        mBlockList = new List<GameObject>();
    }
	// Use this for initialization
	void Start ()
    {
        for (int i = -5; i < 6; i++)
        {
            GameObject block = Instantiate(mBlock, new Vector2(3, i*0.5f), new Quaternion()) as GameObject;
            mBlockList.Add(block);
        }

        for (int i = 0; i < 8; i++)
        {
            mBlockList[Random.Range(0, mBlockList.Count)].SendMessage("SetItem");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}