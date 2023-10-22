namespace Sandbox.Tools
{
	[Library( "tool_networkserializerentityspawner", Title = "NetworkSerializerEntity Spawner", Description = "Spawn NetworkSerializerEntity", Group = "fun" )]
	public class NetworkSerializerEntitySpawner : BaseTool
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
			var ent = new NetworkSerializerEntity
			{
				Position = Owner.EyePosition + Owner.EyeRotation.Forward * 50,
				Rotation = Owner.EyeRotation
			};

			ent.SetModel( modelToShoot );
			ent.Velocity = Owner.EyeRotation.Forward * 1000;
		}
	}
}
