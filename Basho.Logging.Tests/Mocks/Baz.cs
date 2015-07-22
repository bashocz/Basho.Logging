namespace Basho.Logging.Tests.Mocks
{
    class Baz : Foo
    {
        public new static ILog<Baz> Log = new Log<Baz>();
    }
}
