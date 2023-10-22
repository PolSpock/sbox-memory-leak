namespace Sandbox.Tools
{
	[Library( "tool_oncallremoteprocedureentityspawner", Title = "OnCallRemoteProcedureEntity Spawner", Description = "Spawn OnCallRemoteProcedureEntity", Group = "fun" )]
	public class OnCallRemoteProcedureEntitySpawner : BaseTool
	{

		string modelToShoot = "models/citizen_props/crate01.vmdl";

		public override void Simulate()
		{
			if ( Game.IsServer )
			{
				if ( Input.Pressed( "attack1" ) )
				{
					ShootBox();
				}
			}
		}

		void ShootBox()
		{
			var ent = new OnCallRemoteProcedureEntity
			{
				Position = Owner.EyePosition + Owner.EyeRotation.Forward * 50,
				Rotation = Owner.EyeRotation
			};

			ent.SetModel( modelToShoot );
			ent.Velocity = Owner.EyeRotation.Forward * 1000;
		}
	}
}
