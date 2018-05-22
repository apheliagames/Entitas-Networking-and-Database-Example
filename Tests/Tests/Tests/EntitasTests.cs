using Entitas;
using NSpec;

class EntitasTests : nspec
{
    protected Contexts _contexts = null;
    protected Systems _systems = null;
    
    protected void Setup()
    {
        _contexts = new Contexts();
        _systems = new Systems();
    }
}