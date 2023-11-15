using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEMENTPREFAB : MonoBehaviour
{
   
    [SerializeField] private float moveSpeed = 3f;

    private void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
