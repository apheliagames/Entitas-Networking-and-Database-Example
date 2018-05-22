using NSpec;

class Describe_HealthSystem : EntitasTests
{
    void when_executing()
    {        
        GameEntity e = null;

        before = () =>
        {
            Setup();
            var system = new HealthSystem(_contexts);
            _systems.Add(system);
            e = _contexts.game.CreateEntity();
        };

        it["Entity flags destroyed when Health is 0"] = () =>
        {
            //given
            e.AddHealth(0);
            //when
            _systems.Execute();
            //then
            e.isDestroyed.should_be_true();
        };

        it["Entity flags destroyed when Health is less than 0"] = () =>
        {
            //given
            e.AddHealth(-1);
            //when
            _systems.Execute();
            //then
            e.isDestroyed.should_be_true();
        };
        it["Entity doesn't flag destroyed when Health is greater than 0"] = () =>
        {
            ////given
            //e.AddHealth(1);
            //when
            _systems.Execute();
            //then
            e.isDestroyed.should_be_false();
        };
    }
}


