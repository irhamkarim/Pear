﻿using StructureMap;
using System.Web.Http.Dependencies;

namespace DSLNG.PEAR.Web.DependencyResolution
{
    public class StructureMapDependencyResolver : StructureMapDependencyScope, IDependencyResolver
    {
        public StructureMapDependencyResolver(IContainer container)
            : base(container)
        {
        }
        public IDependencyScope BeginScope()
        {
            IContainer child = this.Container.GetNestedContainer();
            return new StructureMapDependencyResolver(child);
        }
    }
}