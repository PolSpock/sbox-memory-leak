using Sandbox;

[Spawnable]
[Library( "ent_net", Title = "Lamp" )]
public partial class NetEntity : ModelEntity
{
	private const int SendModificationsRpc = 269924000;

	public override void Spawn()
	{
		base.Spawn();

		SetModel( "models/citizen_props/crate01.vmdl" );
		SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );

		Tags.Add( "solid" );
	}

	[GameEvent.Tick.Server]
	public void Tick()
	{
		foreach ( var client in Game.Clients )
		{
			SendModifications( client );
		}
	}

	private void SendModifications( IClient client )
	{
		var msg = NetWrite.StartRpc( SendModificationsRpc, this );

		int size = 128;
		msg.Write( size );
		for ( int i = 0; i < size; i++ )
		{
			msg.Write( 1 );
		}

		msg.SendRpc( To.Single( client ), this );
	}

	private void ReceiveModifications( ref NetRead read )
	{
		var count = read.Read<int>();
		for ( var i = 0; i < count; ++i )
		{
			var useless = read.Read<int>();
		}
	}

	protected override void OnCallRemoteProcedure( int id, NetRead read )
	{
		switch ( id )
		{
			case SendModificationsRpc:
				ReceiveModifications( ref read );
				break;
			default:
				base.OnCallRemoteProcedure( id, read );
				break;
		}
	}


	public void Remove()
	{
		Delete();
	}
}
