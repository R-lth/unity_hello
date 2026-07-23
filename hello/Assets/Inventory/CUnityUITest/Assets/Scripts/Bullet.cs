using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    private Vector3 direction; 
    public void Shoot(Vector3 source, Vector3 target) 
    {
        transform.position = source;        
        direction = (target - source).normalized;
        transform.rotation = Quaternion.LookRotation(direction);

        Invoke("DestroyBullet", 5f);        
    } 

    void Update() 
    {
        //transform.Translate(direction * 5.0f * Time.deltaTime);
        
        transform.position += direction * 5.0f * Time.deltaTime;

        //Vector3 pos = transform.position + direction * 5.0f * Time.deltaTime;
        //transform.rotation = Quaternion.LookRotation(pos);
        //transform.position = pos;
    }

    public void DestroyBullet()
    {
        //ObjectPoolBullet.ReturnObject(this); //pool
    }
}


