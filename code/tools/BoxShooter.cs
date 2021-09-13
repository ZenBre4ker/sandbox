namespace Sandbox.Tools
{
	[Library( "tool_boxgun", Title = "Box Shooter", Description = "Shoot boxes", Group = "fun" )]
	public class BoxShooter : BaseTool
	{
		TimeSince timeSinceShoot;
		ModelEntity box;
		public override void Simulate()
		{
			if ( Host.IsClient )
			{
				if ( Input.Pressed( InputButton.Attack1 ) )
				{
					ShootBox();
				}

				if ( Input.Down( InputButton.Attack2 ))
				{
					using ( Prediction.Off() )
					{
						box.Position = Owner.EyePos + Owner.EyeRot.Forward * 500;
						box.ResetInterpolation();
						//box.PhysicsBody.Position = box.Position;
					}
				}
			}
		}

		void ShootBox()
		{
			box = new ModelEntity
			{
				Rotation = Owner.EyeRot
			};

			box.SetModel( "models/citizen_props/crate01.vmdl" );
			box.SetupPhysicsFromModel( PhysicsMotionType.Keyframed );
			box.Position = Owner.EyePos + Owner.EyeRot.Forward * 500;
			//ent.PhysicsBody.Position = ent.Position;
		}
	}
}
