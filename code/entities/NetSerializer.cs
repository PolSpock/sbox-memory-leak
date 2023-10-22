using Sandbox;

[Spawnable]
[Library( "ent_net", Title = "Lamp" )]
public partial class NetSerializer : BaseNetworkable, INetworkSerializer
{

	public int Size;

	void INetworkSerializer.Write( NetWrite write )
	{
		write.Write( Size );
		for ( var i = 0; i < Size; ++i )
		{
			write.Write( 1 );

		}
	}


	void INetworkSerializer.Read( ref NetRead read )
	{

		var count = read.Read<int>();

		for ( var i = 0; i < count; ++i )
		{
			var useless = read.Read<int>();
		}
	}
}
