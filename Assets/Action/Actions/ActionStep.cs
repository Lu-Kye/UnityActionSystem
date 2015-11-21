using UnityEngine;
using UnityEngine.Events;

namespace Action 
{
	/// <summary>
	/// Action step.
	/// </summary>
	public class ActionStep : ActionBase 
	{
		UnityAction<GameObject, float> _step;

		ActionStep(
			GameObject target, 
			float duration, 
			UnityAction<GameObject, float> step,
			UnityAction callback
		) : base(target, duration, callback)
		{
			this._step = step;
		}
		
		/// <summary>
		/// Create step action
		/// </summary>
		/// <param name="target">Target.</param>
		/// <param name="duration">Duration.</param>
		/// <param name="step">Step.</param>
		/// <param name="callback">Callback.</param>
		public static ActionStep Create(
			GameObject target, 
			float duration, 
			UnityAction<GameObject, float> step,
			UnityAction callback = null
		)
		{
			return new ActionStep(target, duration, step, callback);
		}

		/// <summary>
		/// Whether this action is finished
		/// </summary>
		/// <returns><c>true</c> if this instance is finished; otherwise, <c>false</c>.</returns>
		public override bool IsFinished()
		{
			return this._step == null || base.IsFinished();
		}
		
		/// <summary>
		/// Step by delta time
		/// </summary>
		/// <param name="dt">Delta time.</param>
		protected override void Step(float dt)
		{
			if (this._step != null)
				this._step(this._target, this._time / this._duration);
		}
	}
}
