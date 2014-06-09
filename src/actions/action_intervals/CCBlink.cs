﻿namespace CocosSharp
{
	public class CCBlink : CCActionInterval
	{
		public uint Times { get; private set; }


		#region Constructors

		public CCBlink (float duration, uint uBlinks) : base (duration)
		{
			Times = uBlinks;
		}

		#endregion Constructors


		protected internal override CCActionState StartAction (CCNode target)
		{
			return new CCBlinkState (this, target);

		}

		public override CCFiniteTimeAction Reverse ()
		{
			return new CCBlink (Duration, Times);
		}
	}

	public class CCBlinkState : CCActionIntervalState
	{

		protected uint Times { get; set; }

		protected bool OriginalState { get; set; }

		public CCBlinkState (CCBlink action, CCNode target)
			: base (action, target)
		{ 
			Times = action.Times;
			OriginalState = target.Visible;
		}

		protected internal override void Update (float time)
		{
			if (Target != null && !IsDone)
			{
				float slice = 1.0f / Times;
				// float m = fmodf(time, slice);
				float m = time % slice;
				Target.Visible = m > (slice / 2);
			}
		}

		protected internal override void Stop ()
		{
			Target.Visible = OriginalState;
			base.Stop ();
		}

	}
}