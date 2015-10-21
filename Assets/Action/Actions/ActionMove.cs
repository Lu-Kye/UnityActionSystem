using UnityEngine;
using UnityEngine.Events;

namespace Action 
{
	/// <summary>
	/// Action move.
	/// </summary>
	public class ActionMove : ActionBase 
	{
		// Local position from
		Vector3 _from;

		// Local position to
		Vector3 _to;

		ActionMove(
			GameObject target, 
			float duration, 
			Vector3 from, 
			Vector3 to, 
			UnityAction callback
		) : base(target, duration, callback)
		{
			this._from = from;
			this._to = to;
		}

		/// <summary>
		/// Create a move action
		/// </summary>
		/// <param name="target">Target.</param>
		/// <param name="duration">Duration.</param>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		/// <param name="callback">Callback.</param>
		public static ActionMove Create(
			GameObject target, 
			float duration, 
			Vector3 from, 
			Vector3 to, 
			UnityAction callback = null
		)
		{
			return new ActionMove(target, duration, from, to, callback);
		}

		/// <summary>
		/// Step by delta time
		/// </summary>
		/// <param name="dt">Delta time.</param>
		protected override void Step(float dt)
		{
			this._target.transform.localPosition = 
				Vector3.Lerp(this._from, this._to, this._time / this._duration);
		}

		/// <summary>
		/// Finish this action.
		/// </summary>
		protected override void Finish()
		{
			this._target.transform.localPosition = this._to;
			base.Finish();
		}
	}
}