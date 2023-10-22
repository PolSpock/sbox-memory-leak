using Sandbox;
using System;

[Spawnable]
[Library( "ent_networkserializerentity", Title = "NetworkSerializerEntity" )]
public partial class NetworkSerializerEntity : ModelEntity
{

	[Net] public NetSerializer Data { get; set; }

	public override void Spawn()
	{
		base.Spawn();

		SetModel( "models/citizen_props/crate01.vmdl" );
		SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );

		Tags.Add( "solid" );

		Data = new NetSerializer();

	}


	[GameEvent.Tick.Server]
	public void Tick()
	{
		if ( Data != null )
		{
			Data.Size = new Random().Next( 128, 2048 );

			foreach ( var client in Game.Clients )
			{
				Data.WriteNetworkData();
			}
		}


	}

	public void Remove()
	{
		Delete();
	}
}
