using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> stars;
    [SerializeField] List<GameObject> galaxies;
    [SerializeField] int starRate = 10;
    [SerializeField] int galaxyRate = 5;

    private void Start() 
    {
        for (int i = 0; i < starRate; i++)
        {
            Vector3 randomVector = new Vector3(Random.Range(-80, 81), Random.Range(-60, 60), transform.position.z + 10);
            GameObject star = Instantiate(stars[Random.Range(0, stars.Count)]) as GameObject;

            star.transform.position = randomVector;
            star.transform.parent = transform;
            
        }

        for (int i = 0; i < galaxyRate; i++)
        {
            Vector3 randomVector = new Vector3(Random.Range(-80, 81), Random.Range(-60, 60), transform.position.z + 20);
            GameObject galaxy = Instantiate(galaxies[Random.Range(0, galaxies.Count)]) as GameObject;

            galaxy.transform.position = randomVector;
            galaxy.transform.parent = transform;

        }
    }
}

