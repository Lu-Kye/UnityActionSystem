using UnityEngine;
using UnityEngine.Events;

namespace Action 
{
	/// <summary>
	/// Action delay time.
	/// </summary>
	public class ActionDelay : ActionBase 
	{
		ActionDelay(
			float duration,
			UnityAction callback
		) : base(null, duration, callback)
		{
		}

		public static ActionDelay Create(
			float duration,
			UnityAction callback = null
		)
		{
			return new ActionDelay(duration, callback);
		}

		/// <summary>
		/// Whether this action is finished
		/// </summary>
		/// <returns><c>true</c> if this instance is finished; otherwise, <c>false</c>.</returns>
		public override bool IsFinished()
		{
			return this._isFinished;
		}
	}
}