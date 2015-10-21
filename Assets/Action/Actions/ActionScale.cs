using UnityEngine;
using UnityEngine.Events;

namespace Action 
{
	/// <summary>
	/// Action move.
	/// </summary>
	public class ActionScale : ActionBase 
	{
		// Local scale from
		Vector3 _from;
		
		// Local scale to
		Vector3 _to;
		
		ActionScale(
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
		public static ActionScale Create(
			GameObject target, 
			float duration, 
			Vector3 from, 
			Vector3 to, 
			UnityAction callback = null
			)
		{
			return new ActionScale(target, duration, from, to, callback);
		}
		
		/// <summary>
		/// Step by delta time
		/// </summary>
		/// <param name="dt">Delta time.</param>
		protected override void Step(float dt)
		{
			this._target.transform.localScale = 
				Vector3.Lerp(this._from, this._to, this._time / this._duration);
		}
		
		/// <summary>
		/// Finish this action.
		/// </summary>
		protected override void Finish ()
		{
			this._target.transform.localScale = this._to;
			base.Finish();
		}
	}
}