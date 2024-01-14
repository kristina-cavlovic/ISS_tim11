using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkerScript : MonoBehaviour
{
    private Renderer planeRenderer;
    [SerializeField] bool blinking = false;

    private void Start()
    {
        planeRenderer = GetComponent<Renderer>();

        Debug.Log("Transparent");

        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 180);

        // Start the blinking coroutine
        StartCoroutine(BlinkCoroutine());
    }

    private IEnumerator BlinkCoroutine()
    {
        while (true)
        {
            // Check if the plane is active
            if (blinking)
            {
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
                Debug.Log("Blink");
                // Set the color to yellow
                planeRenderer.material.color = Color.yellow;
                yield return new WaitForSeconds(0.25f);
                

                // Set the color to gray
                planeRenderer.material.color = Color.gray;
                yield return new WaitForSeconds(0.25f);
            }
            else
            {
                // If the plane is not active
                
                
                yield return null;
            }
        }
    }
}
