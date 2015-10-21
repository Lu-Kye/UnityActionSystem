using UnityEngine;
using UnityEngine.Events;

namespace Action
{
	/// <summary>
	/// Action sequence
	/// </summary>
	public class ActionSpawn : ActionBase
	{
		ActionBase[] _actions;
		ActionBase _action;
		
		ActionSpawn(
			params ActionBase[] actions
		) : base(null, 0, null)
		{
			this._actions = actions;
			
			for (int i = 0, max = actions.Length; i < max; i++)
			{
				this._duration = Mathf.Max(this._duration, actions[i].Duration);
			}
		}
		
		public static ActionSpawn Create(
			params ActionBase[] actions
			)
		{
			return new ActionSpawn(actions);
		}
		
		/// <summary>
		/// Whether this action is finished
		/// </summary>
		/// <returns><c>true</c> if this instance is finished; otherwise, <c>false</c>.</returns>
		public override bool IsFinished()
		{
			return this._isFinished;
		}
		
		/// <summary>
		/// Step by delta time
		/// </summary>
		/// <param name="dt">Delta time.</param>
		protected override void Step(float dt)
		{
			for (int i = 0, max = this._actions.Length; i < max; i++)
			{
				var action = this._actions[i];
				if (action.IsStopped() || action.IsFinished())
					continue;

				action.Update(dt);
			}
		}
	}
}
