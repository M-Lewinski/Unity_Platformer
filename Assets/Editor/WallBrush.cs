using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallBrush : GridBrush
{

    public Sprite preview;
    public Sprite[] randomSprites;

    public override void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
    {
        Tilemap tilemap = gridLayout.GetComponent<Tilemap>();
        int randomTile = UnityEngine.Random.Range(0, randomSprites.Length);
    }

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
