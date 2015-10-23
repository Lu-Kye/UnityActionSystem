using UnityEngine;
using UnityEngine.Events;

namespace Action 
{
	/// <summary>
	/// Action forever.
	/// </summary>
	public class ActionForever : ActionBase 
	{
		protected ActionBase _action;

		ActionForever(
			ActionBase action
		) 
		{
			this._action = action;
		}
		
		/// <summary>
		/// Create a forever action
		/// </summary>
		/// <param name="target">Target.</param>
		/// <param name="duration">Duration.</param>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		/// <param name="callback">Callback.</param>
		public static ActionForever Create(
			ActionBase action
		)
		{
			return new ActionForever(action);
		}

		/// <summary>
		/// Whether this action is finished
		/// </summary>
		/// <returns><c>true</c> if this instance is finished; otherwise, <c>false</c>.</returns>
		public override bool IsFinished()
		{
			return false;
		}
		
		/// <summary>
		/// Step by delta time
		/// </summary>
		/// <param name="dt">Delta time.</param>
		protected override void Step(float dt)
		{
			this._action.Update(dt);

			// Reset
			if (this._action.IsFinished())
			{
				this._action.Reset();
			}
		}
	}
}
