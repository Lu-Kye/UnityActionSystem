using UnityEngine;
using System.Collections;
using Action;

public class Move : MonoBehaviour {
	public GameObject target;

	// Use this for initialization
	void Start () 
	{
		ActionManager.Instance.Add(
			this.gameObject,
			ActionMove.Create(
				this.target,
				2f,
				Vector3.zero,
				new Vector3(10f, 0f, 0f)
			)
		);
	}
}
