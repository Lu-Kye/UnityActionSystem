using UnityEngine;
using UnityEngine.Events;

namespace Action 
{
	/// <summary>
	/// Action rotate.
	/// </summary>
	public class ActionRotate : ActionBase 
	{
		// Local rotation from
		Quaternion _from;
		
		// Local rotation to
		Quaternion _to;
		
		ActionRotate(
			GameObject target, 
			float duration, 
			Quaternion from, 
			Quaternion to, 
			UnityAction callback
		) : base(target, duration, callback)
		{
			this._from = from;
			this._to = to;
		}
		
		/// <summary>
		/// Create a rotate action
		/// </summary>
		/// <param name="target">Target.</param>
		/// <param name="duration">Duration.</param>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		/// <param name="callback">Callback.</param>
		public static ActionRotate Create(
			GameObject target, 
			float duration, 
			Quaternion from, 
			Quaternion to, 
			UnityAction callback = null
			)
		{
			return new ActionRotate(target, duration, from, to, callback);
		}
		
		/// <summary>
		/// Step by delta time
		/// </summary>
		/// <param name="dt">Delta time.</param>
		protected override void Step(float dt)
		{
			this._target.transform.localRotation = 
				Quaternion.Lerp(this._from, this._to, this._time / this._duration);
		}
		
		/// <summary>
		/// Finish this action.
		/// </summary>
		protected override void Finish()
		{
			this._target.transform.localRotation = this._to;
			base.Finish();
		}
	}
}
