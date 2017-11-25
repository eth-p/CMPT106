﻿using UnityEngine;

/// <summary>
/// An abstract base for projectiles.
/// 
/// This abstracts away collision and movement.
/// </summary>
public abstract class AbstractProjectile : MonoBehaviour {
	// -----------------------------------------------------------------------------------------------------------------
	// Configurable:

	/// <summary>
	/// The speed of the projectile.
	/// </summary>
	public float Speed = 2f;
	
	/// <summary>
	/// The number of ticks before the projectile despawns.
	/// </summary>
	public int Despawn = 120;

	/// <summary>
	/// The layers which will trigger a collision.
	/// </summary>
	public LayerMask CollideLayers;
	
	
	// -----------------------------------------------------------------------------------------------------------------
	// Variables:

	private float angle;
	private Vector2 angle_vec;
	private int despawnIn;
	
	
	// -----------------------------------------------------------------------------------------------------------------
	// Abstract:
	
	/// <summary>
	/// The method called when projectile collides with something.
	/// </summary>
	/// <param name="obj">The collider of object collided with.</param>
	public abstract void OnCollide(Collider2D col);

	
	// -----------------------------------------------------------------------------------------------------------------
	// ProjectileController:

	/// <summary>
	/// Recalculate the projectile's angle vector.
	/// </summary>
	void RecalculateAngle() {
		angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
		angle_vec = new Vector2(
			Mathf.Cos(angle),
			Mathf.Sin(angle)
		);
	}
	
	/// <summary>
	/// Move the projectile forwards.
	/// </summary>
	void Move() {
		transform.position = ((Vector2) transform.position) + (angle_vec * Speed);
	}
	
	/// <summary>
	/// [UNITY] Called when the object is instantiated.
	/// </summary>
	void Start() {
		despawnIn = Despawn;
		RecalculateAngle();
	}
	
	/// <summary>
	/// [UNITY] Called every tick.
	/// </summary>
	void FixedUpdate() {
		if (--despawnIn < 1) {
			gameObject.SetActive(false);
			Destroy(gameObject);
			return;
		}
		
		// Raycast to check for collision.
		// If it collides with something, run OnCollide and destroy the projectile.
		// If it doesn't, move the projectile forwards.
		RaycastHit2D ray = Physics2D.Raycast(transform.position, angle_vec, Speed, CollideLayers);
		if (ray.collider == null) {
			Move();
		} else {
			OnCollide(ray.collider);
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}
	
}