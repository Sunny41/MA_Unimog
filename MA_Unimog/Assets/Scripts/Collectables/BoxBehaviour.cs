using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject[] terrain = GameObject.FindGameObjectsWithTag("Terrain");

        for (int i = 0; i < terrain.Length; i++)
        {
            if (collision.otherCollider.IsTouching(terrain[i].GetComponent<Collider2D>()))
            {
                StartCoroutine("destroyBox");
            }
        }



    }

    IEnumerator destroyBox()
    {
        yield return new WaitForSecondsRealtime(2f);
        Destroy(this.gameObject);
    }
}
