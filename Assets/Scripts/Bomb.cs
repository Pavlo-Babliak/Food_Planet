using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public float explosionRadius = 5;// радиус поражения
	public float power = 500;// сила взрыва	
	public LayerMask mask;

	private Rigidbody[] physicObject;// тут будут все физ. объекты которые есть на сцене

    private void Start()
    {
		if (PlayerPrefs.GetInt("Sound") == 0)
		{
			GetComponent<AudioSource>().enabled = false;
		}
		else
		{
			GetComponent<AudioSource>().enabled = true;
		}
	}
    public void Boom1() 
    {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, explosionRadius, mask);
		foreach (Collider2D hit in colliders) 
		{
			if (hit.attachedRigidbody != null) 
			{
				Vector3 direction = hit.transform.position - transform.position;
				direction.z = 0;
				hit.attachedRigidbody.AddForce(direction.normalized * power);
			}
		}
		gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
		StartCoroutine(Dest());
	}
	public void Boom2()
	{
		Collider2D[] colliders1 = Physics2D.OverlapCircleAll(gameObject.transform.position, explosionRadius*2.25f, mask);
		foreach (Collider2D hit in colliders1)
		{
			if (hit.attachedRigidbody != null)
			{
				Vector3 direction = hit.transform.position - transform.position;
				direction.z = 0;
				hit.attachedRigidbody.AddForce(direction.normalized * power);
			}
		}
		Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, explosionRadius, mask);
		foreach (Collider2D hit in colliders)
		{
			if (hit.attachedRigidbody != null)
			{
				Vector3 direction = hit.transform.position - transform.position;
				direction.z = 0;
				if (hit.GetComponent<NewConnect>()) { hit.GetComponent<NewConnect>().Dest(); }
			}
		}
		gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
		gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
		StartCoroutine(Dest());
	}
	IEnumerator Dest() 
	{
		if (GetComponent<AudioSource>().enabled == true) { GetComponent<AudioSource>().Play(); }
		GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}
}

