using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject cube;
    public float spawnTimeMin, spawnTimeMax;
    
    private void Start()
    {
        StartCoroutine("Spawn");
    }

    public IEnumerator Spawn()
    {
        while (true)
        {
            GameObject cubeRight = null;
            GameObject cubeLeft = null;
            if (Random.Range(0, 100) < 70)
                cubeRight = Instantiate(cube, transform.position + Vector3.right * 0.2f, Quaternion.identity);
            if (Random.Range(0, 100) < 70)
                cubeLeft = Instantiate(cube, transform.position + Vector3.right * -0.2f, Quaternion.identity);

            if (cubeRight != null)
                cubeRight.GetComponent<Cube>().angle = Random.Range(0, 4);
            if (cubeLeft != null)
                cubeLeft.GetComponent<Cube>().angle = Random.Range(0, 4);

            if (Random.Range(0, 100) < 30 && cubeRight != null)
            {
                cubeRight.GetComponent<Cube>().blue = false;
            }
            else if (cubeLeft != null)
            {
                if (cubeRight == null)
                    cubeLeft.GetComponent<Cube>().blue = Random.Range(0, 2) == 0 ? true : false;
                cubeLeft.GetComponent<Cube>().blue = false;
            }
            yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));
        }
    }
}
