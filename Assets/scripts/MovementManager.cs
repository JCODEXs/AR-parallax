using UnityEngine;
using System.Collections;


public class MovementManager : MonoBehaviour
{
    public Movement[] planes; // Array to hold all plane scripts
    public float delayBetweenPlanes = 0.1f; // Delay between movements

    private void Start()
    {
        StartCoroutine(AnimatePlanes());
    }

    private IEnumerator AnimatePlanes()
    {
        while (true)
        {
            foreach (var plane in planes)
            {
                plane.enabled = true; // Enable movement for the current plane
                yield return new WaitForSeconds(delayBetweenPlanes); // Wait for a bit
                plane.enabled = false; // Disable movement
            }
        }
    }
}
