using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Action
{
	/// <summary>
	/// Action manager.
	/// - run actions
	/// </summary>
	public class ActionManager : MonoBehaviour
	{
		Dictionary<GameObject, LinkedList<ActionBase>> _actions = new Dictionary<GameObject, LinkedList<ActionBase>>();

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
			if (!this._actions.ContainsKey(target))
				this._actions[target] = new LinkedList<ActionBase>();
			this._actions[target].AddLast(action);
		}

		// Remove actions of target
		public void Remove(GameObject target)
		{
			if (this._actions.ContainsKey(target))
				this._actions.Remove(target);
		}

		// Remove action of target
		public void Remove(GameObject target, ActionBase action)
		{
			if (this._actions.ContainsKey(target))
				this._actions[target].Remove(action);
		}

		// Update
		void Update()
		{
			var targets = this._actions.Keys.ToList();
			for (int i = 0, max = targets.Count; i < max; i++)
			{
				var target = targets[i];
				if (target == null)
				{
					this.Remove(target);
					continue;
				}

				var actions = this._actions[target];
				var actionNode = actions.First;
				while (actionNode != null)
				{
					var action = actionNode.Value;
					
					if (!action.IsFinished() && !action.IsStopped()) 
						action.Update(Time.deltaTime);
					
					actionNode = actionNode.Next;
					
					if (action.IsFinished()) 
						this._actions[target].Remove(action);
				}
			}
		}
	}
}
