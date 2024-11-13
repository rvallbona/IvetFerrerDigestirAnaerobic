using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneLogic : MonoBehaviour
{
    [SerializeField] private string levelName;
    private Transform dest;
    private float velocity = 3f;
    private void Start()
    {
        dest = GameObject.FindWithTag("Dest").transform;
    }
    private void Update()
    {
        //Movement
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, dest.position, velocity * Time.deltaTime);
        
        //Rotation
        Vector3 direction = dest.position - this.gameObject.transform.position;
        direction.z = 0f;
        if (direction != Vector3.zero)
            this.gameObject.transform.up = direction.normalized;

        if (this.gameObject.transform.position == dest.transform.position)
            SceneManager.LoadScene(levelName);
    }
}
