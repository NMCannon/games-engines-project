using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

class Tile
{ 
    public GameObject theTile;
    // Track tile creation time
    public float creationTime;

    public Tile(GameObject t, float ct)
    {
        theTile = t;
        creationTime = ct;
    }
}

public class GenerateInfinite : MonoBehaviour
{
    public GameObject plane;
    public GameObject player;
    public NavMeshSurface surface;

    int planeSize = 10;
    int halfTilesX = 10;
    int halfTilesZ = 10;

    // For player location
    Vector3 startPos;

    // Hashtable to keep track of all tiles
    Hashtable tiles = new Hashtable();

    // Start is called before the first frame update
    void Start()
    {
        // Generate NavMesh
        StartCoroutine(GenerateNavMesh(surface));


        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        // Get time for tile creation
        float updateTime = Time.realtimeSinceStartup;

        // Generate tiles
        for(int x = -halfTilesX; x < halfTilesX; x++)
        {
            for(int z = -halfTilesZ; z < halfTilesZ; z++)
            {
                Vector3 pos = new Vector3((x * planeSize + startPos.x), 0, (z * planeSize + startPos.z));
                GameObject t = (GameObject)Instantiate(plane, pos, Quaternion.identity);

                string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                t.name = tilename;
                Tile tile = new Tile(t, updateTime);
                tiles.Add(tilename, tile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Find how far the player has moved since last terrain update
        int xMove = (int)(player.transform.position.x - startPos.x);
        int zMove = (int)(player.transform.position.z - startPos.z);

        // If player has moved more than one plane size
        if(Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize)
        {
            // Get time of new tile creation
            float updateTime = Time.realtimeSinceStartup;

            // Force integer position and round to nearest tilesize
            int playerX = (int)(Mathf.Floor(player.transform.position.x / planeSize) * planeSize);
            int playerZ = (int)(Mathf.Floor(player.transform.position.z / planeSize) * planeSize);

            // Generate new tiles
            for(int x = -halfTilesX; x < halfTilesX; x++)
            {
                for(int z = -halfTilesZ; z < halfTilesZ; z++)
                {
                    // Make tiles around the player
                    Vector3 pos = new Vector3((x * planeSize + playerX), 0, (z * planeSize + playerZ));

                    // Create tilename
                    string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();

                    // If tile hasn't been made before, make it
                    if(!tiles.ContainsKey(tilename))
                    {
                        GameObject t = (GameObject)Instantiate(plane, pos, Quaternion.identity);
                        t.name = tilename;
                        Tile tile = new Tile(t, updateTime);
                        tiles.Add(tilename, tile);
                    }
                    // Else tile already exists in the array, update its time
                    else
                    {
                        (tiles[tilename] as Tile).creationTime = updateTime;
                    }
                }
            }

            // Destroy all tiles not just created or with time updated
            // and put new tiles and tiles to be kept in a new hashtable
            Hashtable newTerrain = new Hashtable();
            foreach(Tile tls in tiles.Values)
            {
                if(tls.creationTime != updateTime)
                {
                    // Delete gameobject
                    Destroy(tls.theTile);
                }
                else
                {
                    newTerrain.Add(tls.theTile.name, tls);
                }
            }

            // Copy new hashtable contents to the working hashtable
            tiles = newTerrain;

            startPos = player.transform.position;
        }
    }

    //Coroutine for building navmesh every 5 seconds
    private IEnumerator GenerateNavMesh(NavMeshSurface surface)
    {
        // Keep looping
        while (true)
        {
            yield return new WaitForSeconds(1);
            // Build NavMesh
            surface.BuildNavMesh();
            // Wait 20 seconds before building again
            yield return new WaitForSeconds(20);
        }
    }
}
