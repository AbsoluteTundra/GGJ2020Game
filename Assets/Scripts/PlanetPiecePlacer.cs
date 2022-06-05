using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPiecePlacer : MonoBehaviour
{
    public List<GameObject> planetPiecePrefabs;
    public float pieceScale = 0.2f;

    public float distanceFromPlanet = 0;

    GameObject piece = null;
    public GameObject manager;
    public GameObject destruction;

    public bool hexagon;

    public void Start()
    {
        int index;
        this.transform.Rotate(0, 0, 90);
        if (hexagon && manager.GetComponent<GameManager>().planetHexagonPrefabs.Count != 0)
        {
            index = Random.Range(0, manager.GetComponent<GameManager>().planetHexagonPrefabs.Count);
            piece = Instantiate(manager.GetComponent<GameManager>().planetHexagonPrefabs[index], this.transform.position,this.transform.rotation) as GameObject;
            manager.GetComponent<GameManager>().planetHexagonPrefabs.RemoveAt(index);
        }
        else if (!hexagon && manager.GetComponent<GameManager>().planetPentagonPrefabs.Count != 0)
        {
            index = Random.Range(0, manager.GetComponent<GameManager>().planetPentagonPrefabs.Count);
            piece = Instantiate(manager.GetComponent<GameManager>().planetPentagonPrefabs[index], this.transform.position,this.transform.rotation) as GameObject;
            manager.GetComponent<GameManager>().planetPentagonPrefabs.RemoveAt(index);
        }
        else
        {
            piece = Instantiate(planetPiecePrefabs[Random.Range(0, planetPiecePrefabs.Count)], this.transform.position,this.transform.rotation) as GameObject;
        }
        piece.transform.localScale = new Vector3(pieceScale, pieceScale, pieceScale);
        if (piece.CompareTag("Destroyable"))
        {
            destruction.GetComponent<Destruction>().destructableThings.Add(piece);
            foreach (Renderer r in piece.transform.GetChild(1).GetComponentsInChildren<Renderer>()) 
            {
                r.enabled = false;
            }
        }
    }
}
