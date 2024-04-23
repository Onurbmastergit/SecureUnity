using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCollider : MonoBehaviour
{
    public bool buildAttack = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Build"))
        { 
            Debug.Log("Constru��o");
            buildAttack = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if(collider.CompareTag("Build"))
        {
            buildAttack = false;
        }
    }
}
