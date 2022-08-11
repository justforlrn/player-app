using Player.MongoDB;
using Xunit;

namespace Player;

[CollectionDefinition(PlayerTestConsts.CollectionDefinitionName)]
public class PlayerApplicationCollection : PlayerMongoDbCollectionFixtureBase
{

}
