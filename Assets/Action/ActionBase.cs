using UnityEngine;
using UnityEngine.Events;

namespace Action	
{
	/// <summary>
	/// Action base.
	/// </summary>
	public class ActionBase
	{
		// which run this action
		protected GameObject _target = null;

		// duration of action run time
		protected float _duration = 0f;
		public float Duration
		{
			get { return this._duration; }
		}

		// action excuting time
		protected float _time = 0f;

		// is stop
		protected bool _isStopped = false;

		// callback
		protected UnityAction _callback;

		// Ctor
		public ActionBase()
		{
		}

		// Ctor
		public ActionBase(GameObject target, float duration, UnityAction callback)
		{
			this._target = target;
			this._duration = duration;
			this._callback = callback;
		}

		/// <summary>
		/// Whether this action is stoped
		/// </summary>
		public virtual bool IsStopped()
		{
			return this._isStopped;
		}

		// is finish
		protected bool _isFinished = false;

		/// <summary>
		/// Whether this action is finished
		/// </summary>
		public virtual bool IsFinished() 
		{
			return this._target == null || this._isFinished;
		}

		/// <summary>
		/// Stop this action
		/// </summary>
		public virtual void Stop()
		{
			this._isStopped = true;
		}

		/// <summary>
		/// Finish this action.
		/// </summary>
		protected virtual void Finish()
		{
			this._isFinished = true;
			if (this._callback != null)
				this._callback();
		}

		/// <summary>
		/// Reset this action.
		/// </summary>
		protected virtual void Reset()
		{
			this._time = 0;
			this._isFinished = false;
		}

		/// <summary>
		/// Step by delta time
		/// </summary>
		/// <param name="dt">Delta time.</param>
		protected virtual void Step(float dt)
		{
			// Implemented by derived class
		}

		/// <summary>
		/// Update by delta time
		/// </summary>
		/// <param name="dt">Delta time.</param>
		public virtual void Update(float dt)
		{
			if (this.IsStopped() || this.IsFinished())
				return;

			// Increase time
			this._time += dt;

			// Time cant be bigger than duration
			if (this._time >= this._duration)
				this._time = this._duration;

			// Step by step
			this.Step(dt);

			// Stop if executed
			if (this._time >= this._duration)
				this.Finish();
		}
	}
}
