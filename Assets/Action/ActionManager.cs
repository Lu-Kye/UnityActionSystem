using System.Collections.Generic;
using UnityEngine;

namespace Action
{
	/// <summary>
	/// Action manager.
	/// - run actions
	/// </summary>
	public class ActionManager : MonoBehaviour
	{
		LinkedList<ActionBase> _actions = new LinkedList<ActionBase>();

		// Instance
		static ActionManager _instance;
		public static ActionManager Instance
		{
			get 
			{
				if (_instance == null)
				{
					_instance = new GameObject("ActionManager").AddComponent<ActionManager>();
					GameObject.DontDestroyOnLoad(_instance.gameObject);
					return _instance;
				}
				return _instance;
			}
		}

		/// <summary>
		/// Add action
		/// </summary>
		/// <param name="target">Target which will be used to destory all actions of it.</param>
		/// <param name="action">Action.</param>
		public void Add(GameObject target, ActionBase action)
		{
			this._actions.AddLast(action);
		}

		// Remove an action
		public void Remove(ActionBase action)
		{
			this._actions.Remove(action);
		}

		// Remove actions of target
		public void Remove(GameObject target)
		{

		}

		// Update
		void Update()
		{
			var actionNode = this._actions.First;
			while (actionNode != null)
			{
				var action = actionNode.Value;

				if (!action.IsFinished() && !action.IsStopped()) 
					action.Update(Time.deltaTime);

				actionNode = actionNode.Next;

				if (action.IsFinished()) 
					this.Remove(action);
			}
		}
	}
}
