using System;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultResponseEngine : ResponseEngine
    {
        private Payload payload;
        private ViewRegistry view_registry;
        private RoutingEngine routing_engine;

        public DefaultResponseEngine() : this(new DefaultPayload(), new StubViewRegistry(), new DefaultRoutingEngine())
        {}


        public DefaultResponseEngine(Payload payload, ViewRegistry viewRegistry, RoutingEngine routingEngine)
        {
            this.payload = payload;
            view_registry = viewRegistry;
            routing_engine = routingEngine;
        }


        public void process<ViewModel>(ViewModel view_model)
        {
            payload.store(view_model);
            routing_engine.transfer(view_registry.get_view_for(view_model));    
        }
    }
}