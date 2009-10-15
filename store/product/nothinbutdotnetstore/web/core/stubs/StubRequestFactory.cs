using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_from(HttpContext http_context)
        {
            return new DefaultRequest(new StubMapperRegistry(), http_context.Request.RawUrl,
                                      new StubRequestInfo());
        }

        class StubMapperRegistry : MapperRegistry
        {
            public Mapper<Input, Output> get_mapper_for<Input, Output>()
            {
                return new StubMapper<Input, Output>();
            }
        }

        class StubMapper<T, T1> : Mapper<T, T1>
        {
            public T1 map(T item)
            {
                return default(T1);
            }
        }

        class StubRequestInfo : RequestInfo {}
    }
}