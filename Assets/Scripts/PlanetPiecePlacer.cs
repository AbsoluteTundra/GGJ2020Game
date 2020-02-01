using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPiecePlacer : MonoBehaviour
{
    public List<GameObject> planetPiecePrefabs;
    public float pieceScale = 0.2f;

    public float distanceFromPlanet = 0;

    GameObject piece = null;

    public void Start()
    {
        this.transform.Rotate(0, 0, 90);
        piece = Instantiate(planetPiecePrefabs[Random.Range(0, planetPiecePrefabs.Count)], this.transform.position,this.transform.rotation) as GameObject;
        piece.transform.localScale = new Vector3(pieceScale, pieceScale, pieceScale);
    }

    public void Update()
    {
        //piece.transform.position = (this.transform.position - GameObject.Find("PlanetPrefab").transform.position).normalized * distanceFromPlanet;
        //piece.transform.position = this.transform.position;
        //piece.transform.rotation = this.transform.rotation;
    }
}
