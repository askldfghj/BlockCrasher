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
        for (int i = -4; i < 5; i++)
        {
            for (int j = 4; j >= 1; j--)
            {
                GameObject block = Instantiate(mBlock, new Vector2(i*0.964f, (j*0.31f+3)), new Quaternion()) as GameObject;
                block.SendMessage("SetSprite");
                mBlockList.Add(block);
            }
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