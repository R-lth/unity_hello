using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Car : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();                                                        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.forward);
    }

    private void FixedUpdate()
    {
        
    }
}
