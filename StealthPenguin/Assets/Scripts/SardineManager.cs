using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SardineManager : MonoBehaviour
{
    private float floatingTimer = 0f;
    private float floatingMax = 1f;
    private float floatingDir = 0.01f;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (floatingTimer < floatingMax)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + floatingDir);
            floatingTimer += Time.fixedDeltaTime;
        } else
        {
            floatingDir *= -1;
            floatingTimer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("???");
        if (other.gameObject.layer == 8)
        {
            Debug.Log("WINNER");

            Destroy(this.gameObject);
        }
    }
}
