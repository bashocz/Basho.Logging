namespace Basho.Logging.Tests.Mocks
{
    class FooBar : Foo
    {
        public new static ILog<FooBar> Log = new Log<FooBar>();
    }
}
