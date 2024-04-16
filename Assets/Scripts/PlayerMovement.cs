using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] GameObject playerModel;

    [SerializeField] float movementSpeed = 5f;

    #endregion

    #region Initialization

    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    #endregion

    #region Functions

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }

    void RotatePlayer()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    #endregion
}
