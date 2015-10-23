using UnityEngine;
using UnityEngine.Events;

namespace Action
{
	/// <summary>
	/// Action sequence
	/// </summary>
	public class ActionSequence : ActionBase
	{
		ActionBase[] _actions;
		ActionBase _action;

		int _index;

		ActionSequence(
			params ActionBase[] actions
		) : base(null, 0, null)
		{
			this._actions = actions;
			this._index = 0;

			for (int i = 0, max = actions.Length; i < max; i++)
			{
				this._duration += actions[i].Duration;
			}
		}

		public static ActionSequence Create(
			params ActionBase[] actions
		)
		{
			return new ActionSequence(actions);
		}

		/// <summary>
		/// Reset this action.
		/// </summary>
		public override void Reset()
		{
			base.Reset();
			this._index = 0;
			
			for (int i = 0, max = this._actions.Length; i < max; i++)
			{
				var action = this._actions[i];
				action.Reset();
			}
		}

		/// <summary>
		/// Get the current action.
		/// </summary>
		protected ActionBase Action
		{
			get 
			{
				if (this._actions.Length > this._index)
					return this._actions[this._index];
				return null;
			}
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
		/// Update by delta time
		/// </summary>
		/// <param name="dt">Delta time.</param>
		public override void Update(float dt)
		{
			if (this.IsStopped() || this.IsFinished())
				return;

			// Check 
			var action = this.Action;
			if (action == null)
			{
				this.Finish();
				return;
			}

			if (action.IsStopped())
				return;
			
			// Step by step
			this.Step(dt);

			// Stop if executed
			if (action.IsFinished())
			{
				this._index ++;
				this._time += action.Duration;
			}
		}

		/// <summary>
		/// Step by delta time
		/// </summary>
		/// <param name="dt">Delta time.</param>
		protected override void Step(float dt)
		{
			this.Action.Update(dt);
		}
	}
}
