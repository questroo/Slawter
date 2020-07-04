using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooting : MonoBehaviour
{
    public float damage;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("shooting");
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100.0f);
            if(hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }
}
