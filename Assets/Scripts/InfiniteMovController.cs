using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteMovController : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        Vector3 movimento = new Vector3(velocidade, 0, 0) * Time.deltaTime;
        transform.Translate(movimento, Space.World);
    }
}
