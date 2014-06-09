using System;

namespace CocosSharp
{
	public partial class CCEaseCustom : CCActionEase
	{
		public Func<float, float> EaseFunc { get; private set; }

		#region Constructors

		public CCEaseCustom (CCActionInterval pAction, Func<float, float> easeFunc) : base (pAction)
		{
			EaseFunc = easeFunc;
		}

		#endregion Constructors


		protected internal override CCActionState StartAction (CCNode target)
		{
			return new CCEaseCustomState (this, target);
		}

		public override CCFiniteTimeAction Reverse ()
		{
			return new CCReverseTime (this);
		}
	}


	#region Action state

	public class CCEaseCustomState : CCActionEaseState
	{
		protected Func<float, float> EaseFunc { get; private set; }

		public CCEaseCustomState (CCEaseCustom action, CCNode target) : base (action, target)
		{
			EaseFunc = action.EaseFunc;
		}

		protected internal override void Update (float time)
		{
			InnerActionState.Update (EaseFunc (time));
		}
	}

	#endregion Action state
}