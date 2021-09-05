namespace Sandbox.Tools
{
	[Library( "tool_boxgun", Title = "Box Shooter", Description = "Shoot boxes", Group = "fun" )]
	public class BoxShooter : BaseTool
	{
		TimeSince timeSinceShoot;
		bool useCollisions = false;

		public override void Simulate()
		{
			if ( Host.IsClient )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootBox();
				}

				if ( Input.Pressed( InputButton.Attack2 ))
				{
					Log.Info( "Shoot Trace" );
					var tr = Trace.Ray( Owner.EyePos, Owner.EyePos + Owner.EyeRot.Forward * 2500 ).Ignore(Owner).Run();
					DebugOverlay.Line( tr.StartPos, tr.EndPos, 10, true );
					Log.Info( $"Trace Hit? {tr.Hit}" );
				}
			}
		}

		void ShootBox()
		{
			useCollisions = !useCollisions;
			Log.Info( $"Use Collisions? {useCollisions}." );

			var ent = new ModelEntity
			{
				Position = Owner.EyePos + Owner.EyeRot.Forward * 50,
				Rotation = Owner.EyeRot
			};

			ent.SetModel( "models/citizen_props/crate01.vmdl" );
			if (useCollisions)
			{
				ent.SetupPhysicsFromModel( PhysicsMotionType.Keyframed );
			} 
		}
	}
}
