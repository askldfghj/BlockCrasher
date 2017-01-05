using UnityEngine;
using System.Collections;

public class GameLoader : MonoBehaviour {

    public GameObject[] Blocks;

    void Awake()
    {
        
    }
	// Use this for initialization
	void Start ()
    {
        for (int i = -4; i < 5; i++)
        {
            for (int j = 4; j >= 1; j--)
            {
                Instantiate(Blocks[j], new Vector2(i*0.964f, (j*0.31f+3)), new Quaternion());
            }
        }
        
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}