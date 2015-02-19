using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour 
{
	#region Variables
	private Transform actorTransform;
	private GameObject actorGameObject;
	private Renderer actorRenderer;
	private Rigidbody actorRigidbody;
	private Collider actorCollider;
	#endregion
	
	public Transform aTransform
	{
		get{ return actorTransform? actorTransform: actorTransform = transform; }
	}
	
	public GameObject aGameObject
	{
		get{ return actorGameObject? actorGameObject: actorGameObject = gameObject; }
	}
	
	public Renderer aRenderer
	{
		get{ return actorRenderer? actorRenderer: actorRenderer = renderer; }
	}
	
	public Rigidbody aRigidbody
	{
		get{ return actorRigidbody? actorRigidbody: actorRigidbody = rigidbody; }
	}
	
	public Collider aCollider
	{
		get{ return actorCollider? actorCollider: actorCollider = collider; }
	}
	
	protected virtual void Awake()
	{	
		actorTransform = aTransform;
		actorGameObject = aGameObject;
		actorRenderer = aRenderer;
		actorRigidbody = aRigidbody;
		actorCollider = aCollider;
	}
	
	protected virtual void ActorStart()
	{
	}
}
