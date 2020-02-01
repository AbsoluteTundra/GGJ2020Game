using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPiecePlacer : MonoBehaviour
{
    public List<GameObject> planetPiecePrefabs;
    public float pieceScale = 0.2f;

    public float yOffset = 0;

    GameObject piece;

    public void Start()
    {
        this.transform.Rotate(0, 0, 90);
        piece = Instantiate(planetPiecePrefabs[Random.Range(0,planetPiecePrefabs.Count)], this.transform.position,this.transform.rotation) as  GameObject;
        piece.transform.localScale = new Vector3(pieceScale, pieceScale, pieceScale);
    }

    public void Update()
    {
        piece.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + yOffset, this.transform.eulerAngles.z);
    }
}
