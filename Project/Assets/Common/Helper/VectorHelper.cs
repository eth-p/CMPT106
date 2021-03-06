﻿using UnityEngine;

/// <summary>
/// Extension functions that assist in dealing with vectors.  
/// </summary>
static public class VectorHelper {
	// -----------------------------------------------------------------------------------------------------------------
	// Constants

	/// <summary>
	/// An alias for Vector2(float.MinValue, float.MinValue).
	/// </summary>
	static public Vector2 minValue {
		get {
			return new Vector2(float.MinValue, float.MinValue);
		}
	}
	
	/// <summary>
	/// An alis for Vector2(float.MaxValue, float.MaxValue).
	/// </summary>
	static public Vector2 maxValue {
		get {
			return new Vector2(float.MaxValue, float.MaxValue);
		}
	}
	
	// -----------------------------------------------------------------------------------------------------------------
	// Extension: Vector2
	
	/// <summary>
	/// Get the angle (in radians) between two points. 
	/// </summary>
	/// <param name="self">The origin point.</param>
	/// <param name="point">The other point</param>
	/// <returns>The angle in radians.</returns>
	static public float RadiansBetween(this Vector2 self, Vector2 point) {
		return Mathf.Atan2(
			point.y - self.y,
			point.x - self.x
		);
	}

	/// <summary>
	/// Get a vector for the angle between two points.
	/// </summary>
	/// <param name="self">The origin point.</param>
	/// <param name="point">The other point.</param>
	/// <returns>A vector.</returns>
	static public Vector2 VectorBetween(this Vector2 self, Vector2 point) {
		float angle = RadiansBetween(self, point);
		return new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
	}

	/// <summary>
	/// Get a clamped vector.
	/// </summary>
	/// <param name="self">The vector to clamp.</param>
	/// <param name="min">The minimum.</param>
	/// <param name="max">The maximum.</param>
	/// <returns>The clamped vector.</returns>
	static public Vector2 Clamp(this Vector2 self, Vector2 min, Vector2 max) {
		return Vector2.Max(min, Vector2.Min(max, self));
	}
	
}