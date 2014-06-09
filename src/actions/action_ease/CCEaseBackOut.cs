namespace CocosSharp
{
	public class CCEaseBackOut : CCActionEase
	{
		#region Constructors

		public CCEaseBackOut (CCActionInterval pAction) : base (pAction)
		{
		}

		#endregion Constructors


		protected internal override CCActionState StartAction (CCNode target)
		{
			return new CCEaseBackOutState (this, target);
		}

		public override CCFiniteTimeAction Reverse ()
		{
			return new CCEaseBackIn ((CCActionInterval)InnerAction.Reverse ());
		}
	}


	#region Action state

	public class CCEaseBackOutState : CCActionEaseState
	{
		public CCEaseBackOutState (CCEaseBackOut action, CCNode target) : base (action, target)
		{
		}

		protected internal override void Update (float time)
		{
			InnerActionState.Update (CCEaseMath.BackOut (time));
		}
	}

	#endregion Action state
}