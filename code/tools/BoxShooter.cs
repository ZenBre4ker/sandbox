namespace Sandbox.Tools
{
	[Library( "tool_boxgun", Title = "Box Shooter", Description = "Shoot boxes", Group = "fun" )]
	public class BoxShooter : BaseTool
	{
		TimeSince timeSinceShoot;

		public override void Simulate()
		{
			if ( Host.IsClient )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootBox();
				}

				if ( Input.Down( InputButton.Attack2 ) && timeSinceShoot > 0.05f )
				{
					timeSinceShoot = 0;
					ShootBox();
				}
			}
		}

		void ShootBox()
		{
			var ent = new ModelEntity
			{
				Rotation = Owner.EyeRot
			};

			ent.SetModel( "models/citizen_props/crate01.vmdl" );
			ent.SetupPhysicsFromModel( PhysicsMotionType.Keyframed );
			ent.Position = Owner.EyePos + Owner.EyeRot.Forward * 50;
		}
	}
}
