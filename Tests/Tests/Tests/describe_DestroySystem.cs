using NSpec;

class Describe_DestroySystem : EntitasTests
{
    void when_executing()
    {
        GameEntity e = null;

        before = () =>
        {
            Setup();
            var system = new DestroySystem(_contexts);
            _systems.Add(system);
            e = _contexts.game.CreateEntity();
        };

        it["destroy entities that are flagged as destroyed"] = () =>
        {
            //given
            e.isDestroyed = true;
            //when
            _systems.Execute();
            //then
            e.isEnabled.should_be_false();
            _contexts.game.count.should_be(0);
        };

        it["don't destroy entities that are not flagged as destroyed"] = () =>
        {
            //when
            _systems.Execute();
            //then
            e.isEnabled.should_be_true();
            _contexts.game.count.should_be(1);
        };        
    }
}