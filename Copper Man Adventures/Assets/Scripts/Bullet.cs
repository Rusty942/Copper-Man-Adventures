using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 20f;
	public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
	rb.velocity = transform.right * speed;       
    }

	void OnTriggerEnter2d (Collider2D hitInfo)
	{
		Criminal criminal = hitInfo.GetComponent<Criminal>();
		if(criminal != null)
		{
			Debug.Log("Hit Criminal");
			criminal.Die();
		}
		Destroy(gameObject);
	}
}
